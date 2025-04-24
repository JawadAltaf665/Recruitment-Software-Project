using static System.Net.Mime.MediaTypeNames;

namespace Recruitment_Software_Project.Models.ModelClasses
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Recruiter" or "JobSeeker"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public ICollection<Job> PostedJobs { get; set; }
        //public ICollection<Application> Applications { get; set; }
    }
}
