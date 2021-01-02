using CS434.API.MODELS.Request;
using CS434.API.MODELS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.Interfaces
{
    interface IUserService
    {
        Task<MessageModel> SignUp(SignUpRequestModel signUpRequestModel);
        LoginModel SignIn(SignInRequestModel signInRequestModel);
    }
}
