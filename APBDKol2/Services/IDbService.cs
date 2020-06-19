using APBDKol2.DTOs.Requests;
using APBDKol2.Models;

namespace APBDKol2.Services
{
    public interface IDbService
    {
         Artist GetArtist(int id);
         void UpdateArtistsPerformanceDate(int idArtist, int idEvent,UpdateDateRequest request);
    }
}