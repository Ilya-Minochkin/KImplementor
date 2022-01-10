using BusinessLayer;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Exceptions;
using KImplementor.Authentification;
using KImplementor.Utils;
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
        private readonly AuthService _authService;
        public AuthController(ServiceManager serviceManager)
        {
            _userService = serviceManager.UserService;
            _authService = serviceManager.AuthService;
        }

        [HttpPost("/login")]
        public IActionResult Login(string username, string password)
        {
            var identity = _authService.GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var response = new LoginResponse(_authService.GetToken(identity), username);

            return Json(response);
        }

        
    }
}
