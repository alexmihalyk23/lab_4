using jijaWEB.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace jijaWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase

    {
        private IConfiguration _config;
        private readonly jijaWEBContext _context;
        public TokenController(IConfiguration config, jijaWEBContext context)
        {
            _config = config;
            _context = context;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]Users login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private string BuildToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.login),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            Console.WriteLine("huy" + tokenDescriptor.Subject.ToString());
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private UserModel Authenticate(Users login)
        {
            UserModel user = null;
            var _users = _context.Users.OrderBy(u => u.login).Select(u => new { lgn = u.login, pswd = u.password, rol = u.id_role });
            foreach (var usr in _users)
            {
                try
                {
                    if (login.login == usr.lgn && login.password == usr.pswd)
                    {
                        user = new UserModel { login = usr.lgn, password = usr.pswd, Role = usr.rol};
                    }
                }
                catch (System.InvalidOperationException ex)
                {
                    Unauthorized();
                }
            }
            return user;
        }
        private class UserModel
        {
            public string login { get; set; }
            public string password { get; set; }

            public string Role { get; set; }
        }
    }
}
