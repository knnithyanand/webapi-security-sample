using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Samples.WebApiSecurity.TokenService.Helpers;
using Samples.WebApiSecurity.TokenService.Models;

namespace Samples.WebApiSecurity.TokenService.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody] AccessCredential cred)
        {
            if (IsValidUserAndPasswordCombination(cred.Username,cred.Password))
                return new ObjectResult(TokenHelper.GenerateToken(cred.Username));
            return BadRequest();
        }

        // A simple authentication method that passes when both username and password are same.
        private bool IsValidUserAndPasswordCombination(string username, string password) => username == password;
    }
}
