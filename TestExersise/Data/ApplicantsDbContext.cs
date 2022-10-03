using Microsoft.EntityFrameworkCore;

namespace TestExersise.Data;


public class ApplicantsDbContext : DbContext
{
    public ApplicantsDbContext(DbContextOptions<ApplicantsDbContext> options)
        :base(options)
    {
        
    }
    public virtual DbSet<Applicant> Applicants { get; set; }
    public virtual DbSet<Cards> Cards { get; set; }
}