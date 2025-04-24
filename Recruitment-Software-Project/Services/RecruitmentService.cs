using Recruitment_Software_Project.Models.Common;
using Recruitment_Software_Project.Models.Data;
using Recruitment_Software_Project.Models.ModelClasses;

namespace Recruitment_Software_Project.Services
{

    public interface IRecruitmentService
    {
        public Task<Response> RegistrationRequest(User addUserRequest);
        public Task<Response> LoggedInRequest();
    }
    public class RecruitmentService: IRecruitmentService
    {
        private readonly RecruitmentDBContext dBContext;

        public RecruitmentService(RecruitmentDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Response> LoggedInRequest()
        {
            Response response = new Response();
            try
            {
                
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<Response> RegistrationRequest(User addUserRequest)
        {
            Response response = new Response();
            try
            {
                await dBContext.Users.AddAsync(addUserRequest);
                dBContext.SaveChangesAsync();
                response.StatusCode = 200;
                response.ResponseMessage = "OKAY!";
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
