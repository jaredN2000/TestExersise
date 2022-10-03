using Microsoft.EntityFrameworkCore;

namespace TestExersise.Data;


public class ApplicantsDbContext : DbContext
{
    public ApplicantsDbContext(DbContextOptions<ApplicantsDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Cards> Cards { get; set; }
}