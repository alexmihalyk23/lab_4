using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jijaWEB.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserModel Authenticate(Users login)
        {
            UserModel user = null;
            var _users = _context.Users.OrderBy(u => u.login).Select(u => new { lgn = u.login, pswd = u.password });
            foreach (var usr in _users)
            {


                try
                {

                    if (login.login == usr.lgn && login.password == usr.pswd)
                    {


                        user = new UserModel { login = usr.lgn, password = usr.pswd };
                    }
                }
                catch (System.InvalidOperationException ex)
                {
                    Console.WriteLine("Неверный логин или пароль");
                }
            }
            return user;
        }
        private class UserModel
        {
            public string login { get; set; }
            public string password { get; set; }
        }
    }
}
