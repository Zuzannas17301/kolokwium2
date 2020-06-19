using APBDKol2.DTOs.Requests;
using APBDKol2.Exceptions;
using APBDKol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKol2.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly IDbService _service;

        public ArtistsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetArtist(int id)
        {
            try
            {
                var res = _service.GetArtist(id);
                return Ok(res);
            }
            catch (ArtistDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{IdArtist:int}/events/{IdEvent:int}")]
        public IActionResult UpdateArtistsPerformanceDate(int IdArtist, int IdEvent, UpdateDateRequest request)
        {
            try
            {
                _service.UpdateArtistsPerformanceDate(IdArtist, IdEvent, request);
                return Ok();
            }
            catch (ArtistDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (EventDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (ArtistDoesntPerformOnEventException e)
            {
                return NotFound(e.Message);
            }
            catch (EventAlreadyStartedException e)
            {
                return NotFound(e.Message);
            }
            catch (PerformanceDateOutsideEventTimeException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}