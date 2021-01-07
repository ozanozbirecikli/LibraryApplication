using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS434.API.Interfaces;
using CS434.API.MODELS.Request;
using CS434.API.MODELS.Response;
using CS434.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CS434.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignIn")]
        public LoginModel SignIn([FromBody] SignInRequestModel signInRequestModel)
        {
            return _userService.SignIn(signInRequestModel);
        }

        [HttpPost("SignUp")]
        public Task<MessageModel> SignUp([FromBody] SignUpRequestModel signUpRequestModel)
        {
            return _userService.SignUp(signUpRequestModel);
        }

    }
}
