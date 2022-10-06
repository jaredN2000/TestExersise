namespace TestExersise;

public class BarclayCard : Cards,ICheckEligibility
{
    public BarclayCard()
    {
        this.CardName = "Barclaycard";
        this.Apr = 18;
        this.PromoMeg = "A lot of life can happen in two years"; 
    }

    public Cards? Cards => this;

    public bool CheckEligibility(int age, int income)
    {
        return income >= 30000 && age >= 18;
    }
}