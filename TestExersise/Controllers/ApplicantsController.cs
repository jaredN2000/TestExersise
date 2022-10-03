using Microsoft.AspNetCore.Mvc;
using TestExersise.Data;

namespace TestExersise.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status201Created)]
public class ApplicantController: ControllerBase
{
    // The context for the database that stores the applicant data
    private readonly ApplicantsDbContext _context;
    //Context is set
    public ApplicantController(ApplicantsDbContext context) => _context = context; 
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(Applicant user)
    {
        //tells the database to add the applicant that has been provided through the post api call 
        await _context.Applicants.AddAsync(user);
        await _context.SaveChangesAsync(); 
        
        
        //Calculate the applicants age by subtracting there date of birth from the date today. 
        var age = CalculateAge(user.Dob); 
        
        //Check the applicant is old enough to be eligible for a credit card 
        if (age >= 18)
        {
            /* TODO Improve card eligibility
             The test exercise has set requirements for card eligibility, this
             is unlikly to be the case in a full implementation and so should be changed to have card 
             requirements stored in the cards database and then checks against the card requirements checked*/
            if (user.Income > 30000)
            { 
                //Applicant has an income of £30,000 or more and so should be offered a Barclaycard credit card
                user.AvaliableCards = new Cards
                {
                     CardName = "Barclaycard", Apr = 18, PromoMeg = "A lot of life can happen in two years"
                }; 
            }
            else
            {
                //Applicant has an income of less than £30,000 and so should be offered a Vanquis credit card 
                user.AvaliableCards = new Cards
                {
                    CardName = "Vanquis", Apr = 28, PromoMeg = "Discover a credit card to suit you."
                }; 
            }
        }
        /*User is not eligible for a credit card as they are under 18 so an appropriate message is given.
        This post function currently sends a card back so an card object is created with a message saying
        that the applicant is not old enough for a credit card */ 
        else
        {
            user.AvaliableCards = new Cards
            {
                 CardName = "No cards", Apr = 0, PromoMeg = "You must be 18 years old to have a credit card"
            }; 
        }
        
        /* TODO only enter a card into card database when the credit card isn't already present in the database
         The current implementation adds the credit card that the applicant is eligible for but does not check 
         in any way if the card is already present in the database. This works for the requirements of the task 
         because the task simply states that looking at the database you should be able to see the card the user was 
         offered. However multiple duplicate cards in the database is redundant and not good practice */
        //Tells the database to add the credit card to the database
        await _context.Cards.AddAsync(user.AvaliableCards);
        await _context.SaveChangesAsync(); 
        
        
        //Returns the card offered
        //Not best practice as a strictly restful API should not be passing data back from a post request 
        return new JsonResult(user.AvaliableCards);
    }
    
    //get function to get an APPLICANT from there ID
    [HttpGet("id")]
    [ProducesResponseType(typeof(Applicant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var applicant = await _context.Applicants.FindAsync(id);
        return applicant == null ? NotFound() : Ok(applicant); 
    }
    
    //Function to calculate date of birth of the applicant
    public int CalculateAge(DateTime dob)
    {
        var today = DateTime.Today;
        var age = today.Year - dob.Year;
        
        return (age); 
    }
}