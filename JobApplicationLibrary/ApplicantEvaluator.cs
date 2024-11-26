using JobApplicationLibrary.Models.Enums;

namespace JobApplicationLibrary;

public class ApplicantEvaluator
{
    public bool IsEligible(int yearsOfExperience, bool hasRequiredSkills)
    {
        return yearsOfExperience >= 5 && hasRequiredSkills;
    }

    public bool IsOfRequiredAge(int age)
    {
        return age >= 18 && age <= 50;
    }

    public decimal CalculateSalary(int yearsOfExperience)
    {
        if (yearsOfExperience >= 10)
        {
            return 100000m;
        }
        else if (yearsOfExperience >= 5)
        {
            return 70000m;
        }
        else
        {
            return 50000m;
        }
    }

    public ApplicationStatus GetApplicationStatus(bool isEligible, bool hasJobOffer)
    {
        if (isEligible && hasJobOffer)
        {
            return ApplicationStatus.Accepted;
        }
        else if (isEligible)
        {
            return ApplicationStatus.Pending;
        }
        else
        {
            return ApplicationStatus.Rejected;
        }
    }
}
