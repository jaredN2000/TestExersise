using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TestExersise;
using TestExersise.Data;

namespace TechExersiseTests;

public class Tests
{
    DecisionEngine decisionEngine = new DecisionEngine();
    
    [SetUp]
    public void Setup() { }
    
    [Test]
    public void CheckAge()
    {
        var dob = new DateTime(2000, 10, 02);
        var expected = 22; 

        var result =  decisionEngine.GetAge(dob); 
        
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CheckBarclycard()
    {
        var applicant = new Applicant()
        {
            FirstName = "Jhon",
            LastName = "Smith",
            Income = 30000,
            Dob = new DateTime(2002, 10, 02)
        };
        var expected = "Barclaycard";

        var result = decisionEngine.GetCard(applicant); 
        
        Assert.That(result.Cards.CardName, Is.EqualTo(expected));
    }
    
    [Test]
    public void CheckVanquis()
    {
        var applicant = new Applicant()
        {
            FirstName = "Jhon",
            LastName = "Smith",
            Income = 2000,
            Dob = new DateTime(2002, 10, 02)
        };
        var expected = "Vanquis";

        var result = decisionEngine.GetCard(applicant); 
        
        Assert.That(result.Cards.CardName, Is.EqualTo(expected));
    }
    
    [Test]
    public void CheckNotEligible()
    {
        var applicant = new Applicant()
        {
            FirstName = "Jhon",
            LastName = "Smith",
            Income = 2000,
            Dob = new DateTime(2022, 10, 02)
        };

        var result = decisionEngine.GetCard(applicant); 
        
        Assert.That(result.Cards, Is.EqualTo(null));
    }
    
}