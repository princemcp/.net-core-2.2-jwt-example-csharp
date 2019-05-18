using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Mega.API.Helper;
using Mega.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;

namespace Mega.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppSettings _appSettings;

        public AuthController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            if (Username == "prince" && Password == "121212")
            {
                string guid = Guid.NewGuid().ToString();
                var claims = new[] {
                    new Claim("Username" , Username),
                    new Claim(JwtRegisteredClaimNames.Jti ,guid ),
                    new Claim("Role" , "Admin")
                };
                
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
                var token = new JwtSecurityToken(
                    issuer: "http://abc.com",
                    audience: "http://abc.com",
                    expires: DateTime.Now.AddMinutes(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256
                    )
                    );
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        username = Username
                    }
                    );
            }
            return Unauthorized();
        }
    }
}