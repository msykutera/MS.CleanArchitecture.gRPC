using Application.Common.Exceptions;
using Application.CreateLicense;
using Application.IntegrationTests.Common;
using Domain;
using FluentAssertions;

namespace Application.IntegrationTests;

[TestFixture]
public class CreateLicenseTests : Testing
{
    [Test]
    public async Task LicenseIsSuccesfullyCreated()
    {
        var expectedUserId = "test-user";
        var expectedExpires = DateTime.UtcNow.AddYears(1);
        var command = new CreateLicenseRequest(expectedUserId, expectedExpires);

        await SendAsync(command);

        var license = await FindAsync<License>(1);

        license.Should().NotBeNull();
        license!.UserId.Should().Be(expectedUserId);
        license!.Expires.Should().Be(expectedExpires);
    }

    [Test]
    public async Task LicenseIsNotCreatedWhenUserIdIsMissing()
    {
        var command = new CreateLicenseRequest("", DateTime.UtcNow.AddYears(1));
        var action = async () => await SendAsync(command);

        await action.Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task LicenseIsNotCreatedWhenPastExpiresDate()
    {
        var command = new CreateLicenseRequest("test-user", DateTime.UtcNow.AddYears(-1));
        var action = async () => await SendAsync(command);

        await action.Should().ThrowAsync<ValidationException>();
    }
}