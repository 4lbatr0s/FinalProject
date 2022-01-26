using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService; //create a service to answer the requests.

        public AuthController(IAuthService authService) //injection.
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto) //email & password.
        {
            var userToLogin = _authService.Login(userForLoginDto); //for authService, create an IUserService on backend.
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data); //create the access token for the Login Dto properties.
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
                //UserExists function returns a false value if user already exists, true if does not.
            var userExists = _authService.UserExists(userForRegisterDto.Email); //check whether user already exists or not.
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            //we pass the password to create hash value, dto to save our user in database.
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data); //creates the access token by using an ITokenHelper returns token value and success message.
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
