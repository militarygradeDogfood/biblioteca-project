using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        // GET: api/<EjemploController>
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }



        // GET api/<EjemploController>/5
        [HttpGet("{id}")]
        //public ActionResult<User> GetUser(int id)
            public IActionResult GetUser(int id)
        {
            // Devuelve un usuario específico por su ID
            User user = _userService.FindUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<EjemploController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] User user)
        {
            if (user == null) {
                return NotFound();
            }
            _userService.RegisterUser(user.getName(), user.getRole());
            return Ok();
        }

        // PUT api/<EjemploController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EjemploController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            User user = _userService.FindUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
