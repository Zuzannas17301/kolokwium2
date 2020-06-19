using System;
using Microsoft.EntityFrameworkCore;

namespace APBDKol2.Models
{
    public class MusicDbContext : DbContext
    {
        
        public DbSet<Event> Event { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<ArtistEvent> ArtistEvent { get; set; }
        public DbSet<EventOrganiser> EventOrganiser { get; set; }
        
        public MusicDbContext(){}

        public MusicDbContext(DbContextOptions opts) : base(opts)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Organiser>((builder) =>
            {
                builder.HasKey(p => p.IdOrganiser);          
                builder.Property(p => p.IdOrganiser).ValueGeneratedOnAdd();
                builder.Property(p => p.Name).HasMaxLength(50).IsRequired();                  
                builder.HasMany(p => p.EventOrganisers)
                    .WithOne(p => p.Organiser)
                    .HasForeignKey(p => p.IdOrganiser);

                builder.HasData(
                    new Organiser{IdOrganiser = 1, Name = "art"},
                    new Organiser{IdOrganiser = 2, Name = "rmf"});
            });
            
            modelBuilder.Entity<Event>((builder) =>
            {
                builder.HasKey(p => p.IdEvent);         
                builder.Property(p => p.IdEvent).ValueGeneratedOnAdd();
                builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

                builder.HasData(
                    new Event {IdEvent = 1, Name = "Opener", StartDate = DateTime.Parse("01/07/2019"), EndDate = DateTime.Parse("04/07/2019")},
                    new Event {IdEvent = 2, Name = "Woodstock", StartDate = DateTime.Parse("01/06/2020"), EndDate = DateTime.Parse("06/06/2020")});
            });
            
            modelBuilder.Entity<Artist>((builder) =>
            {
                builder.HasKey(p => p.IdArtist);
                builder.Property(p => p.IdArtist).ValueGeneratedOnAdd();
                builder.Property(p => p.NickName).HasMaxLength(20).IsRequired();

                builder.HasData(
                    new Artist {IdArtist = 1, NickName = "Bob"},
                    new Artist {IdArtist = 2, NickName = "Hannah"});
            });
            
            modelBuilder.Entity<EventOrganiser>((builder) =>
            {
                builder.HasKey(p => p.IdEvent);
                builder.HasKey(p => p.IdOrganiser);
                builder.HasOne(p => p.Organiser)
                    .WithMany(p => p.EventOrganisers)
                    .HasForeignKey(p => p.IdOrganiser);
                builder.HasOne(p => p.Event)
                    .WithMany(p => p.EventOrganisers)
                    .HasForeignKey(p => p.IdEvent);
                builder.HasData(
                    new EventOrganiser {IdEvent = 1, IdOrganiser = 1},
                    new EventOrganiser {IdEvent = 2, IdOrganiser = 2});
            });
            
            modelBuilder.Entity<ArtistEvent>((builder) =>
            {
                builder.HasKey(p => p.IdEvent);
                builder.HasKey(p => p.IdArtist);
                builder.HasOne(p => p.Artist)
                    .WithMany(p => p.ArtistEvents)
                    .HasForeignKey(p => p.IdArtist);
                builder.HasOne(p => p.Event)
                    .WithMany(p => p.ArtistEvents)
                    .HasForeignKey(p => p.IdEvent);
                builder.HasData(
                    new ArtistEvent{IdEvent = 1, IdArtist = 1, PerformanceDate = DateTime.Parse("03/07/2019")},
                    new ArtistEvent{IdEvent = 2, IdArtist = 2,PerformanceDate = DateTime.Parse("05/06/2020")});

            });
            
        }
    }
}