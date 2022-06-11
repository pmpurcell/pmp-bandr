using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        public ActionResult getMatch(int recId, int swiperId)
        {
            Match match = _matchRepository.getMatchByIds(recId, swiperId);
            if (match == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(match);
            }
        }

        [HttpGet("{userId}")]
        public ActionResult getUserMatch(int userId)
        {
            List<Match> matches = _matchRepository.getUserMatches(userId);
            if (matches == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(matches);
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

        [HttpPatch("{id}")]

        public ActionResult updateMatch(int recId, int swiperId, Match updateMatch)
        {
            Match match = _matchRepository.getMatchByIds(recId, swiperId);
            if (match != null)
            {
                _matchRepository.updateMatch(updateMatch);
                return Ok(updateMatch);
            }
            else
            {
                return BadRequest(updateMatch);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult deleteMatch(int id)
        {
            try
            {
                _matchRepository.deleteMatch(id);
                return Ok(id);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/Relationship/{recId}/{swiperId}/{matchBool}")]
        public IActionResult FindRelationship(int recId, int swiperId, bool matchBool)
        {
            bool matchexists = _matchRepository.checkMatchExists(recId, swiperId);
            if (!matchexists)
            {
                Match newMatch = new Match()
                {
                    swiperId = recId,
                    swiperMatch = matchBool,
                    recId = swiperId,
                    recMatch = false,

                };

                _matchRepository.createMatch(newMatch);
                return Ok(newMatch);
            } else if (matchexists)
            {
            // Match existingMatch = _matchRepository.getMatchByRecId(recId); //
            Match match = _matchRepository.getMatchByIds(recId, swiperId);

            Match updateMatch = new Match()
            {
                swiperId = swiperId,
                swiperMatch = match.swiperMatch,
                recId = recId,
                recMatch = matchBool,

            };

                _matchRepository.updateMatch(updateMatch);
                // Check value of relationships in updateMethod //

                    return Ok(updateMatch);
                }
            else
            {
                return BadRequest();
            }
        }
    }
}
