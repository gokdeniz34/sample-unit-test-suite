namespace JobApplicationLibrary.Tests;

using JobApplicationLibrary.Models.Enums;
using Xunit;

public class ApplicantEvaluatorTests
{
    [Theory]
    [InlineData(5, true, true)]
    [InlineData(4, true, false)]
    [InlineData(6, false, false)]
    [InlineData(10, true, true)]    public void IsEligible_ReturnsCorrectResult(int yearsOfExperience, bool hasRequiredSkills, bool expected)
    {
        // Arrange
        var evaluator = new ApplicantEvaluator();

        // Act
        var result = evaluator.IsEligible(yearsOfExperience, hasRequiredSkills);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(25, true)]
    [InlineData(17, false)]
    [InlineData(50, true)]
    [InlineData(51, false)]
    public void IsOfRequiredAge_ReturnsCorrectResult(int age, bool expected)
    {
        // Arrange
        var evaluator = new ApplicantEvaluator();

        // Act
        var result = evaluator.IsOfRequiredAge(age);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(12, 100000)]
    [InlineData(7, 70000)]
    [InlineData(2, 50000)]
    public void CalculateSalary_ReturnsCorrectSalary(int yearsOfExperience, decimal expectedSalary)
    {
        // Arrange
        var evaluator = new ApplicantEvaluator();

        // Act
        var result = evaluator.CalculateSalary(yearsOfExperience);

        // Assert
        Assert.Equal(expectedSalary, result);
    }

    [Theory]
    [InlineData(true, true, ApplicationStatus.Accepted)]
    [InlineData(true, false, ApplicationStatus.Pending)]
    [InlineData(false, true, ApplicationStatus.Rejected)]
    [InlineData(false, false, ApplicationStatus.Rejected)]
    public void GetApplicationStatus_ReturnsCorrectStatus(bool isEligible, bool hasJobOffer, ApplicationStatus expectedStatus)
    {
        // Arrange
        var evaluator = new ApplicantEvaluator();

        // Act
        var result = evaluator.GetApplicationStatus(isEligible, hasJobOffer);

        // Assert
        Assert.Equal(expectedStatus, result);
    }
}
