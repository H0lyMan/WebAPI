using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostUserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public PostUserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (_authService.GetUser(id) == 11)
            {
                return Ok(new { message = "Użytkownik o ID 11 istnieje." });
            }
            else
            {
                return NotFound(new { message = "Użytkownik o ID 11 nie istnieje." });
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] User newUser)
        {
            _authService.CreateUser(newUser = new User { Id = 11, Passwd = "passwd", Username = "newuser" });
            return Ok(new { message = "POST request received." });
        }
    }
}
