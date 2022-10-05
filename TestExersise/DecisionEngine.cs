namespace TestExersise;

public class DecisionEngine
{
    public int GetAge(DateTime dob)
    {
        //Calculate the applicants age by subtracting there date of birth from the date today. 
        var today = DateTime.Today;
        var age = today.Year - dob.Year;
        return age; 
    }

    public ICheckEligibility GetCard(Applicant applicant)
    {
        var age = GetAge(applicant.Dob);
        Cards? card;

        var income = applicant.Income;
        
        foreach (var eligiblecard in AllCards.cards)
        {
            var eligible = eligiblecard.CheckEligibility(age, income);
            if (eligible == true)
            {
                return eligiblecard; 
            }
        }

        return null; 
    }
    
    
    
    
}