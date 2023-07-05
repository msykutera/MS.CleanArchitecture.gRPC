using Application.Common.Exceptions;
using Application.CreateLicense;
using Application.IntegrationTests.Common;
using Application.ValidateLicense;
using Domain;
using FluentAssertions;

namespace Application.IntegrationTests;

[TestFixture]
public class ValidateLicenseTests : Testing
{
    [Test]
    public async Task LicenseIsSuccesfullyValidated()
    {
        var expectedUserId = "test-user";
        var createCommand = new CreateLicenseRequest(expectedUserId, DateTime.UtcNow.AddYears(1));

        var createResult = await SendAsync(createCommand);
        createResult.Success.Should().BeTrue();

        var validateCommand = new ValidateLicenseRequest(expectedUserId);

        var validateResult = await SendAsync(validateCommand);
        validateResult.Success.Should().BeTrue();
    }

    [Test]
    public async Task LicenseIsNotValidatedIfUserIdDoesntExist()
    {
        var expectedUserId = "nonexisting-user";
        var validateCommand = new ValidateLicenseRequest(expectedUserId);

        var validateResult = await SendAsync(validateCommand);
        validateResult.Success.Should().BeFalse();
    }

    [Test]
    public async Task LicenseShouldntBeValidatedIfExpired()
    {
        var expectedUserId = "new-user";
        await AddAsync(new License(0, expectedUserId, DateTime.UtcNow.AddYears(-1)));

        var validateCommand = new ValidateLicenseRequest(expectedUserId);

        var validateResult = await SendAsync(validateCommand);
        validateResult.Success.Should().BeFalse();
    }

    [Test]
    public async Task LicenseIsNotValidetedIfMissingUserId()
    {
        var command = new CreateLicenseRequest("", DateTime.UtcNow.AddYears(1));
        var action = async () => await SendAsync(command);

        await action.Should().ThrowAsync<ValidationException>();
    }
}