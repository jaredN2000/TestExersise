using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestExersise;

public class Applicant
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApplicantId { get; set;}
    [Required]
    public string? FirstName { get; set;}
    
    public string? LastName { get; set;}
    
    public DateTime Dob { get; set;}
    
    public int Income { get; set;}

    public Cards? AvaliableCards { get; set; }
}