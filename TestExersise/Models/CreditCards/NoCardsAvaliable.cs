namespace TestExersise;

public class NoCardsAvaliable:ICheckEligibility
{
    public Cards? Cards => null;

    public bool CheckEligibility(int age, int income)
    {
        return true; 
    }
}