using System;
using System.Linq;
using APBDKol2.DTOs.Requests;
using APBDKol2.Exceptions;
using APBDKol2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDKol2.Services
{
    public class EfDbService : IDbService
    {
        private readonly MusicDbContext _context;

        public EfDbService(MusicDbContext context)
        {
            _context = context;
        }

        public Artist GetArtist(int id)
        {
            var artist = _context.Artist
                .Include(e => e.ArtistEvents)
                .SingleOrDefault(e => e.IdArtist == id);

            if (artist == null)
            {
                throw new ArtistDoesNotExistException($"Artist with id = {id} does not exists!");
            }

            artist.ArtistEvents = artist.ArtistEvents.OrderByDescending(e => e.PerformanceDate).ToList();

            return artist;
        }

        public void UpdateArtistsPerformanceDate(int idArtist, int idEvent,UpdateDateRequest request)
        {
            var artist = _context.Artist
                .SingleOrDefault(e => e.IdArtist == idArtist);

            if (artist == null)
            {
                throw  new ArtistDoesNotExistException($"Artist with id = {idArtist} does not exist!");
            }

            var eventt = _context.Event
                .SingleOrDefault(e => e.IdEvent == idEvent);

            if (eventt == null)
            {
                throw new EventDoesNotExistException($"Event with id = {idEvent} does not exist!");
            }

            var artistEvent = _context.ArtistEvent
                .SingleOrDefault(ae => ae.IdArtist == idArtist && ae.IdEvent == idEvent);
            if (artistEvent == null)
            {
                throw new ArtistDoesntPerformOnEventException(
                    $"Artist with id = {idArtist} doesn't perform on event with id = {idEvent}!");
            }

            if (eventt.StartDate <= DateTime.Now)
            {
                throw new EventAlreadyStartedException($"Event with id = {idEvent} has already started!");
            }

            if (request.PerformanceDate < eventt.StartDate && request.PerformanceDate > eventt.EndDate)
            {
                throw new PerformanceDateOutsideEventTimeException("Performance is not being organised in event's timeframe!");
            }

            artistEvent.PerformanceDate = request.PerformanceDate;
            _context.ArtistEvent.Update(artistEvent);

            _context.SaveChanges();

        }
    }
}