using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Recruitment_Software_Project.Models.Common;
using Recruitment_Software_Project.Models.Data;
using Recruitment_Software_Project.Models.ModelClasses;

namespace Recruitment_Software_Project.Services
{

    public interface IRecruitmentService
    {
        public Task<Response> RegistrationRequest(User addUser);
        public Task<Response> AuthenticationRequest(LoggedInRequest user);
    }
    public class RecruitmentService: IRecruitmentService
    {
        private readonly RecruitmentDBContext dBContext;

        public RecruitmentService(RecruitmentDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Response> AuthenticationRequest(LoggedInRequest user)
        {
            Response response = new Response();
            try
            {
                var existingUser = await dBContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (existingUser == null)
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "User Not found!";
                    return response;
                }
                var passHash = new PasswordHasher<LoggedInRequest>();
                var result = passHash.VerifyHashedPassword(user, existingUser.Password, user.Password);
               
                if(result == PasswordVerificationResult.Failed)
                {
                    response.StatusCode = 401;
                    response.ResponseMessage = "Invalid password!";
                    return response;
                }
                if (result == PasswordVerificationResult.Success)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = "User Authenticated!";
                    response.ResultData = existingUser;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<Response> RegistrationRequest(User addUser)
        {
            Response response = new Response();
            try
            {
                if(addUser == null)
                {
                    response.StatusCode = 401;
                    response.ResponseMessage = "Undefined user record!";
                    return response;
                }
                // Hash Password
                var passHasher = new PasswordHasher<User>();
                addUser.Password = passHasher.HashPassword(addUser, addUser.Password);

                if(addUser.Id == 0)
                {
                    await dBContext.Users.AddAsync(addUser);
                    await dBContext.SaveChangesAsync();
                    response.StatusCode = 201;
                    response.ResponseMessage = "User Added!";
                }
                else
                {
                    dBContext.Users.Update(addUser);
                    await dBContext.SaveChangesAsync();
                    response.StatusCode = 200;
                    response.ResponseMessage = "User Updated!";
                }
                
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }
    }
}
