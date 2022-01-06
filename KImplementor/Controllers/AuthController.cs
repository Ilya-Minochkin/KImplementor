using BusinessLayer;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Exceptions;
using KImplementor.Authentification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KImplementor.Controllers
{
    public class AuthController : Controller
    {
        // тестовые данные вместо использования базы данных
        //private List<UserModel> people = new List<UserModel>
        //{
        //    new UserModel {="admin@gmail.com", Password="12345", Role = "admin" },
        //    new UserModel { Login="qwerty@gmail.com", Password="55555", Role = "user" }
        //};
        private readonly UserService _userService;
        public AuthController(ServiceManager serviceManager)
        {
            _userService = serviceManager.UserService;
        }

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            try
            {
                UserModel userModel = _userService.GetUserModelByEmail(email);
                if (userModel.User.Password == password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.User.Email),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, userModel.User.Roles.First().ToString())
                    };
                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }

            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
