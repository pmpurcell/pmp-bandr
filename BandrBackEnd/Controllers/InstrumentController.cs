using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : Controller
    {

        private readonly IInstrumentRepository _instrumentRepository;

        public InstrumentController(IInstrumentRepository instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;
        }

        [HttpGet]

        public ActionResult getAllInstruments()
        {
            List<Instrument> instruments = _instrumentRepository.getAllInstruments();
            if (instruments == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(instruments);
            }
        }

        [HttpGet("{id}")]

        public ActionResult getSingleInstrument(int id)
        {
            Instrument instruments = _instrumentRepository.getInstrumentById(id);
                {
                if(instruments == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(instruments);
                }
            }
        }
    }
}
