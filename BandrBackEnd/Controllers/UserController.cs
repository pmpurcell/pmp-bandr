using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult getSingleUser(int Id)
        {
            User user = _userRepository.getSingleUser(Id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost]
        public ActionResult createUser(User newUser)
        {
            if(newUser == null)
            {
                return NotFound();
            }
            else
            {
                _userRepository.createUser(newUser);
                return Ok();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult updateUser(int id, User updateUser)
        {
            User user = _userRepository.getSingleUser(id);

            if (user != null)
            { 
                _userRepository.updateUser(updateUser);
                return Ok(updateUser);
            }
            else
            {
                return BadRequest(user);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.deleteUser(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
