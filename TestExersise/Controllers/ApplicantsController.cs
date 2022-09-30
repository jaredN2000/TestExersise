using Microsoft.AspNetCore.Mvc;
using TestExersise;
using TestExersise.Data;

namespace TestExersise.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status201Created)]
public class ApplicantController: ControllerBase
{
    private readonly ApplicantsDbContext _context;

    public ApplicantController(ApplicantsDbContext context) => _context = context; 
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(Applicant user)
    {
        await _context.Applicants.AddAsync(user);
        await _context.SaveChangesAsync(); 
        
        
        
        var today = DateTime.Today;
        var age = today.Year - user.Dob.Year;
        
        if (age >= 18)
        {
            if (user.Income > 30000)
            { 
                user.AvaliableCards = new Cards
                {
                     CardName = "Barclaycard", Apr = 18, PromoMeg = "A lot of life can happen in two years"
                }; 
            }
            else
            {
                user.AvaliableCards = new Cards
                {
                    CardName = "Vanquis", Apr = 28, PromoMeg = "Discover a credit card to suit you."
                }; 
            }
        }
        else
        {
            user.AvaliableCards = new Cards
            {
                 CardName = "No cards", Apr = 0, PromoMeg = "You must be 18 years old to have a credit card"
            }; 
        }
        
        await _context.Cards.AddAsync(user.AvaliableCards);
        await _context.SaveChangesAsync(); 

        return new JsonResult(user.AvaliableCards);
    }
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(Applicant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var applicant = await _context.Applicants.FindAsync(id);
        return applicant == null ? NotFound() : Ok(applicant); 
    }
}