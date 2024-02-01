﻿using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;

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

        // GET: /Auth?username=USERNAME&password=PASSWORD
        [HttpGet]
        public IActionResult Get(string username, string password)
        {
            var user = _userService.Authenticate(username, password);

            if (user == null)
            {
                return BadRequest(new { message = "Benutzername oder Passwort ist falsch." });
            }

            var token = _userService.GenerateJwtToken(user.Benutzername);
            return Ok(new { token });
        }
    }

}