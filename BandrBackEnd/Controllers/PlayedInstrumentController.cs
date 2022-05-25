using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedInstrumentController : Controller
    {
        private readonly IPlayedInstrumentRepository _playedInstrumentRepository;

        public PlayedInstrumentController(IPlayedInstrumentRepository playedInstrumentRepository)
        {
            _playedInstrumentRepository = playedInstrumentRepository;
        }   

        [HttpGet("user/{userId}")]

        public ActionResult getPlayedInstrumentsByUser(int userId)
        {
            List<PlayedInstrument> playedInstruments = _playedInstrumentRepository.getPlayedInstrumentsByUser(userId);
            if (playedInstruments == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playedInstruments);
            }
        }

        [HttpGet("{id}")]
        public ActionResult getSinglePlayedInstrument(int id)
        {
            PlayedInstrument playedInstrument = _playedInstrumentRepository.getSinglePlayedInstrument(id);
            if(playedInstrument == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playedInstrument);
            }
        }

        [HttpPost]
        public ActionResult addPlayedInstrument(PlayedInstrument playedInstrument)
        {
            if(playedInstrument == null)
            {
                return NotFound();
            }
            else
            {
                _playedInstrumentRepository.addPlayedInstrument(playedInstrument);
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public ActionResult removePlayedInstruments(int id)
        {
            try
            {
                _playedInstrumentRepository.removePlayedInstrument(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
