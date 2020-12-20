using CS434.API.Interfaces;
using CS434.API.MODELS.Database;
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

        public MessageModel SignIn(SignInRequestModel signInRequestModel)
        {
            using (var dbContext = new DEV_Context())
            {
                try
                {
                    MessageModel messageModel = new MessageModel();
                    var user = dbContext.Set<Users>().FirstOrDefault(x => x.EMAIL == signInRequestModel.Email);
                    if (user == null)
                    {
                        messageModel.Result = false;
                        messageModel.Message = "Kullanıcı Bulunamamaktadır!";
                        return messageModel;
                    }
                    else if (user.PASSWORD != signInRequestModel.Password)
                    {
                        messageModel.Result = false;
                        messageModel.Message = "Kullanıcı bilgileriniz hatalı!";
                        return messageModel;
                    }

                    messageModel.Result = true;
                    messageModel.Message = "Başarıyla girilmiştir!";
                    return messageModel;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        public Task<MessageModel> SignUp(SignUpRequestModel signUpRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
