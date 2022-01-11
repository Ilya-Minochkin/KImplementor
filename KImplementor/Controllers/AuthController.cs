using BusinessLayer;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Exceptions;
using KImplementor.Utils;
using Microsoft.AspNetCore.Mvc;

namespace KImplementor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var identity = _authService.GetIdentity(username, password);
                var response = new LoginResponse(_authService.GetToken(identity), username);

                return Json(response);
            }
            catch (UserNotFoundException)
            {

                return BadRequest(new { errorText = "Invalid email" });
            }
            catch (WrongPasswordException)
            {
                return BadRequest(new { errorText = "Invalid password." });
            }
        }
        [HttpPost("signup")]
        public IActionResult SignUp(UserModel userModel)
        {
            if (_userService.GetUserModelByEmail(userModel.User.Email).User != null)
            {
                return BadRequest(new { errorText = "This user is already exists" });
            }

            _userService.SaveUserModel(userModel);

            return Ok();
        }

        [HttpGet]
        public IActionResult Test()
        {
            return new JsonResult(new { field = 1, fieldd = "11" });
        }


    }
}
