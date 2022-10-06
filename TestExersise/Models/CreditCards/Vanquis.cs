namespace TestExersise;

public class Vanquis: Cards,ICheckEligibility
{
    public Vanquis()
    {
        this.CardName = "Vanquis";
        this.Apr = 28;
        this.PromoMeg = "Discover a credit card to suit you"; 
    }
    
    public Cards? Cards => this;

    public bool CheckEligibility(int age, int income)
    {
        return age >= 18;
    }
}