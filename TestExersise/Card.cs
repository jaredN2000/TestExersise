using System.ComponentModel.DataAnnotations;

namespace TestExersise;

public class Cards
{

    [Key]
    public int CardId { get; set; }
    public string? CardName { get; set;}
    
    public int Apr { get; set;}
    
    public string? PromoMeg { get; set;}
    
}