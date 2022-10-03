using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Moq;
using TestExersise;
using TestExersise.Data;

namespace TechExersiseTests;

public class Tests
{
    
    TestExersise.Controllers.ApplicantController test; 
    
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptions<ApplicantsDbContext>();
        var mockDbContext = new Mock<ApplicantsDbContext>(options);
        var mockApplicantsDBset = new Mock<DbSet<Applicant>>(); 
        var mockCardsDBset = new Mock<DbSet<Cards>>();
        mockDbContext.Setup(m => m.Applicants).Returns(mockApplicantsDBset.Object); 
        mockDbContext.Setup(m => m.Cards).Returns(mockCardsDBset.Object); 
        test = new TestExersise.Controllers.ApplicantController(mockDbContext.Object); 
       
    }

    
    [Test]
    public void CheckAge()
    {
        var eighteenYearsOld = new DateTime(2004, 01, 02);

        var result = test.CalculateAge(eighteenYearsOld); 
        
        Assert.AreEqual(18, result);
    }
    
}