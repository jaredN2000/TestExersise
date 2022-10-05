using Microsoft.AspNetCore.Mvc;
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
    public void CheckBarclycardOutput()
    {
        var applicant = new Applicant()
        {
            FirstName = "Jared",
            LastName = "Norton",
            Dob = new DateTime(2000, 10, 02),
            Income = 30000
        };

        var card = new Cards()
        {
            CardName = "Barclaycard",
            Apr = 18,
            PromoMeg = "A lot of life can happen in two years"
        };
        var expected = new JsonResult(card);

        var output = test.Post(applicant);
        var result = output.Result; 
        
        Assert.That(result, Is.EqualTo(expected));
    }
}