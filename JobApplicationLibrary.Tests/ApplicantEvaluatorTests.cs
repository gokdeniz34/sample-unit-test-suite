namespace JobApplicationLibrary.Tests;

using JobApplicationLibrary.Models.Enums;
using Xunit;

public class ApplicantEvaluatorTests
{
    [Theory]
    [InlineData(5, true, true)]
    [InlineData(4, true, false)]
    [InlineData(6, true, false)]
    [InlineData(10, true, true)]
    public void IsEligible_ReturnsCorrectResult(int yearsOfExperience, bool hasRequiredSkills, bool expected)
    {
        // Arrange
        var evaluator = new ApplicantEvaluator();

        // Act
        var result = evaluator.IsEligible(yearsOfExperience, hasRequiredSkills);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(GetApplicantDataFromFile))]
    public void IsEligible_ReturnsCorrectResultWithData(int yearsOfExperience, bool hasRequiredSkills, bool expected)
    {
        // Arrange
        var evaluator = new ApplicantEvaluator();

        // Act
        var result = evaluator.IsEligible(yearsOfExperience, hasRequiredSkills);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsEligible_WithDefaultValues_ReturnsFalse()
    {
        var evaluator = new ApplicantEvaluator();

        var result = evaluator.IsEligible(0, false);

        Assert.False(result);
    }

    [Theory]
    [InlineData(25, true)]
    [InlineData(17, false)]
    [InlineData(50, true)]
    [InlineData(51, false)]
    public void IsOfRequiredAge_ReturnsCorrectResult(int age, bool expected)
    {
        var evaluator = new ApplicantEvaluator();

        var result = evaluator.IsOfRequiredAge(age);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(12, 100000)]
    [InlineData(7, 70000)]
    [InlineData(2, 50000)]
    public void CalculateSalary_ReturnsCorrectSalary(int yearsOfExperience, decimal expectedSalary)
    {
        var evaluator = new ApplicantEvaluator();

        var result = evaluator.CalculateSalary(yearsOfExperience);

        Assert.Equal(expectedSalary, result);
    }

    [Theory]
    [InlineData(true, true, ApplicationStatus.Accepted)]
    [InlineData(true, false, ApplicationStatus.Pending)]
    [InlineData(false, true, ApplicationStatus.Rejected)]
    [InlineData(false, false, ApplicationStatus.Rejected)]
    public void GetApplicationStatus_ReturnsCorrectStatus(bool isEligible, bool hasJobOffer, ApplicationStatus expectedStatus)
    {
        var evaluator = new ApplicantEvaluator();

        var result = evaluator.GetApplicationStatus(isEligible, hasJobOffer);

        Assert.Equal(expectedStatus, result);
    }


    public static IEnumerable<object[]> GetApplicantDataFromFile()
    {
        var data = File.ReadAllLines("C:\\Users\\gokde\\source\\repos\\JobApplication\\JobApplicationLibrary.Tests\\applicants.txt")
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(line => line.Split(','))
                        .Select(parts => new object[]
                        {
                            int.Parse(parts[0]),      // YearsOfExperience
                            bool.Parse(parts[1]),     // HasRequiredSkills
                            bool.Parse(parts[2])      // IsEligible
                        });

        return data;
    }
}
