using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestExersise;

public class Cards
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int CardId { get; set; }
    [Required]
    public string CardName { get; set;}
    
    public int Apr { get; set;}
    
    public string? PromoMeg { get; set;}

    //public abstract bool CheckEligibility(int age, int income);

}