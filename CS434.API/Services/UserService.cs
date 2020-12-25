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
    public class UserService : IUserService
    {
        IConfiguration configuration;
        public UserService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public LoginModel SignIn(SignInRequestModel signInRequestModel)
        {
            using (var dbContext = new DEV_Context())
            {
                try
                {
                    LoginModel loginModel = new LoginModel();
                    var user = dbContext.Set<Users>().FirstOrDefault(x => x.EMAIL == signInRequestModel.Email);
                    if (user == null)
                    {
                        loginModel.Result = false;
                        loginModel.Message = "Invalid Username or Password!";
                        loginModel.User = null;
                        return loginModel;
                    }
                    else if (user.PASSWORD != signInRequestModel.Password)
                    {
                        loginModel.Result = false;
                        loginModel.Message = "Wrong Password!";
                        loginModel.User = null;
                        return loginModel;
                    }

                    loginModel.Result = true;
                    loginModel.Message = "User Logged in Successfully!";
                    loginModel.User = user;
                    return loginModel;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        public async Task<MessageModel> SignUp(SignUpRequestModel signUpRequestModel)
        {
            using (var dbContext = new DEV_Context())
            {
                using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                {


                    try
                    {
                        MessageModel messageModel = new MessageModel();
                        var sorgu = dbContext.Set<Users>().FirstOrDefault(x => x.EMAIL == signUpRequestModel.Email);
                        if (sorgu != null)
                        {
                            messageModel.Message = "Bu mail hesabıyla daha önce kaydolunmuştur.";
                            messageModel.Result = false;
                            return messageModel;
                        }
                        else
                        {
                            var user = new Users
                            {
                                NAME = signUpRequestModel.Name,
                                SURNAME = signUpRequestModel.Surname,
                                EMAIL = signUpRequestModel.Email,
                                PASSWORD = signUpRequestModel.Password,
                                ID_ROLE = signUpRequestModel.User_role


                        };

                            await dbContext.Set<Users>().AddAsync(user);
                            await dbContext.SaveChangesAsync();

                            messageModel.Message = "Kullanıcı başarıyla oluşturulmuştur.";
                            messageModel.Result = true;

                            dbContext.SaveChanges();
                            dbContextTransaction.Commit();

                            return messageModel;
                        }
                    }
                    catch (Exception e)
                    {

                        dbContextTransaction.Rollback();
                        Console.WriteLine(e.InnerException.Message);
                        throw;
                    }

                }

            }
        }
    
    
    
    
    
    
    }
}
