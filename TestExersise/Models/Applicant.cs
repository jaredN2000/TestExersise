using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestExersise;
/* This is the Applicant class it is an object to represent an applicant for credit cards.
 An applicant has a First and last name, a date of birth, an income in addition to a card object 
 representing the card they have been offered and an ID that is used to store them in the 
 applicant database*/
public class Applicant
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApplicantId { get; set;}
    [Required]
    public string? FirstName { get; set;}
    
    public string? LastName { get; set;}
    
    public DateTime Dob { get; set;}
    
    public int Income { get; set;}

    public int? CardID { get; set; }
}