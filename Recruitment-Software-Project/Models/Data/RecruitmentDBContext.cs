using Microsoft.EntityFrameworkCore;
using Recruitment_Software_Project.Models.ModelClasses;

namespace Recruitment_Software_Project.Models.Data
{
    public class RecruitmentDBContext: DbContext
    {
        public RecruitmentDBContext(DbContextOptions<RecruitmentDBContext> options)
                : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
