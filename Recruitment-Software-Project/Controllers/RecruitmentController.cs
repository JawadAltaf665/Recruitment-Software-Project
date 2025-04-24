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
        private readonly RecruitmentService recruitmentService;

        public RecruitmentController(RecruitmentService recruitmentService)
        {
            this.recruitmentService = recruitmentService;
        }

        [HttpPost("")]
        public async Task<Response> RegistrationRequest(User addUserRequest)
        {
            return await recruitmentService.RegistrationRequest(addUserRequest);
        }
    }
}
