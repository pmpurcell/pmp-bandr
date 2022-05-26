using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedGenreController : Controller
    {
        private readonly IPlayedGenreRepository _playedGenreRepository;

        public PlayedGenreController(IPlayedGenreRepository playedGenreRepository)
        {
            _playedGenreRepository = playedGenreRepository;
        }

        [HttpGet("user/{userId}")]

        public ActionResult getPlayedGenresByUser(int userId)
        {
            List<PlayedGenre> playedGenres = _playedGenreRepository.getPlayedGenresByUser(userId);
            if (playedGenres == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playedGenres);
            }
        }

        [HttpGet("{id}")]
        public ActionResult getSinglePlayedGenre(int id)
        {
            PlayedGenre playedGenre = _playedGenreRepository.getSinglePlayedGenre(id);
            if (playedGenre == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playedGenre);
            }
        }

        [HttpPost]
        public ActionResult addPlayedGenre(PlayedGenre playedGenre)
        {
            if (playedGenre == null)
            {
                return NotFound();
            }
            else
            {
                _playedGenreRepository.addPlayedGenre(playedGenre);
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public ActionResult removePlayedGenre(int id)
        {
            try
            {
                _playedGenreRepository.removePlayedGenre(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
