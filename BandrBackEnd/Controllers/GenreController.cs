using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {

        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]

        public ActionResult getAllInstruments()
        {
            List<Genre> genres = _genreRepository.getAllGenres();
            if (genres == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(genres);
            }
        }

        [HttpGet("{id}")]

        public ActionResult getSingleGenre(int id)
        {
            Genre genre = _genreRepository.getGenreById(id);
            {
                if (genre == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(genre);
                }
            }
        }
    }
}
