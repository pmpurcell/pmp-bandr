using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : Controller
    {
      private readonly IParticipantRepository _participantRepository;

        public ParticipantController(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        [HttpGet]
        public ActionResult getParticipantById(int id)
        {
            Participant participant = _participantRepository.GetParticipantById(id);
            if (participant == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(participant);
            }
        }

        [HttpPost]
        public ActionResult createParticipant(Participant newParticipant)
        {
            if (newParticipant == null)
            {
                return NotFound();
            }
            else
            {
                _participantRepository.CreateParticipant(newParticipant);
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public ActionResult deleteParticipant(int id)
        {
            try
            {
                _participantRepository.DeleteParticipant(id);
                return Ok(id);
            }

            catch (Exception ex)
            {
                return BadRequest("DELETE FAILED");
            }
        }
    }
}
