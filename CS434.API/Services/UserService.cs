using CS434.API.Interfaces;
using CS434.API.MODELS.Request;
using CS434.API.MODELS.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.Services
{
    public class UserService: IUserService
    {
        IConfiguration configuration;
        public UserService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public SignInResponseModel SignIn(SignInRequestModel signInRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<MessageModel> SignUp(SignUpRequestModel signUpRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
