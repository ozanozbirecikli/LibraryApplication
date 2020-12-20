using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS434.API.Interfaces;
using CS434.API.MODELS.Request;
using CS434.API.MODELS.Response;
using CS434.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CS434.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;
        IConfiguration configuration;
        public UsersController(IConfiguration configuration)
        {
            userService = new UserService(configuration);
        }

        [HttpPost("SignIn")]
        public MessageModel SignIn(SignInRequestModel signInRequestModel)
        {
            return userService.SignIn(signInRequestModel);
        }

    }
}
