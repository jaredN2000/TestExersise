namespace TestExersise;

public interface ICheckEligibility
{
    public Cards? Cards { get; }
    public bool CheckEligibility(int age, int income);
}