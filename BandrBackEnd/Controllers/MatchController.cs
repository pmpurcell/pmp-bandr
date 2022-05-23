using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        public ActionResult getMatch(int id)
        {
            Match match = _matchRepository.getMatch(id);
            if (match == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(match);
            }
        }

        [HttpPost]
        public ActionResult createMatch(Match newMatch)
        {
            if (newMatch == null)
            {
                return NotFound();
            }
            else
            {
                _matchRepository.createMatch(newMatch);
                return Ok();
            }
        }

        [HttpPatch("match/id")]

        public ActionResult updateMatch(int id, Match updateMatch)
        {
            try
            {
                _matchRepository.updateMatch(updateMatch);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(updateMatch);
            }
        }

        [HttpDelete("match/id")]
        public ActionResult deleteMatch(int id)
        {
            try
            {
                _matchRepository.deleteMatch(id);
                return Ok(id);
            }

            catch (Exception ex)
            {
                return BadRequest("DELETE FAILED");
            }
        }
    }
}
