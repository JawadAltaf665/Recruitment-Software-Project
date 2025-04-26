using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment_Software_Project.Models.Common;
using Recruitment_Software_Project.Models.ModelClasses;
using Recruitment_Software_Project.Services;

namespace Recruitment_Software_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentService recruitmentService;

        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            this.recruitmentService = recruitmentService;
        }

        [HttpPost("RegistrationRequest")]
        public async Task<Response> RegistrationRequest(User addUser)
        {
            return await recruitmentService.RegistrationRequest(addUser);
        }

        [HttpPost("AuthenticationRequest")]
        public async Task<Response> AuthenticationRequest(LoggedInRequest user)
        {
            return await recruitmentService.AuthenticationRequest(user);
        }
    }
}
