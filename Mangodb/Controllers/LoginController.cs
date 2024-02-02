using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;
using Microsoft.AspNetCore.Authorization;

namespace MangoExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _userService;

        public LoginController(LoginService userService)
        {
            _userService = userService;
        }

        // GET login = ergebniss ein Token
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(string username, string password)
        {
            var user = _userService.Authenticate(username, password);

            if (user == null || user.Blockiert)
            {
                return BadRequest(new { message = "Benutzername oder Passwort ist falsch oder Benutzer ist blockiert." });
            }

            var token = _userService.GenerateJwtToken(user.Benutzername);
            return Ok(new { token });
        }
    }

}
