using Microsoft.AspNetCore.Mvc;
using TestExersise.Data;

namespace TestExersise.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status200OK)]
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
        //instance of decisionEngine
        var decisionEngine = new DecisionEngine();
        
        //tells the database to add the applicant that has been provided through the post api call 
        await _context.Applicants.AddAsync(user);
        //Saves changes to the database
        await _context.SaveChangesAsync(); 
        
        //Gets the card the user is offered from the decision engine 
        var Offer = decisionEngine.GetCard(user);

        if (Offer.Cards != null)
        {
            /* TODO only enter a card into card database when the credit card isn't already present in the database
            The current implementation adds the credit card that the applicant is eligible for but does not check 
             in any way if the card is already present in the database. This works for the requirements of the task 
             because the task simply states that looking at the database you should be able to see the card the user was 
             offered. However multiple duplicate cards in the database is redundant and not good practice */
            await _context.Cards.AddAsync(Offer.Cards);
            await _context.SaveChangesAsync();

            //store the offered card in the user
            user.CardID = Offer.Cards.CardId;

            //Returns the card offered
            //Not best practice as a strictly restful API should not be passing data back from a post request 
            return new CreatedResult("Applicant added to database",Offer.Cards);
        } else
        {
            return new OkObjectResult("Applicant is not 18 so cannot be offered any cards");
        }
        
    }
    
    /* get function to get an APPLICANT from there ID - Don't strictly need this for this task but made it while
      following a tutorial so might as well keep it */
    [HttpGet("id")]
    [ProducesResponseType(typeof(Applicant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var applicant = await _context.Applicants.FindAsync(id);
        return applicant == null ? NotFound() : Ok(applicant); 
    }
}