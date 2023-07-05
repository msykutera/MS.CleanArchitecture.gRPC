using Grpc.Net.Client;
using Client;
using Google.Protobuf.WellKnownTypes;

var startup = new Startup();

using var channel = GrpcChannel.ForAddress(startup.ApiSettings.Url);
var client = new Licensor.LicensorClient(channel);

await CreateLicense();
await ValidateLicense();
await ValidateMissingLicense();

async Task CreateLicense()
{
    var expires = DateTime.UtcNow.AddDays(1);
    var createRequest = new CreateLicenseGrpcRequest { UserId = "Michal", Expires = Timestamp.FromDateTime(expires) };
    var createResult = await client.CreateLicenseAsync(createRequest);

    Console.WriteLine(createResult.Success ? "License created succesfully." : "Failed to create license.");
}

async Task ValidateLicense()
{
    var validateRequest = new ValidateLicenseGrpcRequest { UserId = "Michal" };
    var validateResult = await client.ValidateLicenseAsync(validateRequest);

    Console.WriteLine(validateResult.Success ? "License is valid." : "There is no valid license.");
}

async Task ValidateMissingLicense()
{
    var validateRequestMissingLicense = new ValidateLicenseGrpcRequest { UserId = "Missing" };
    var validateResultMissingLicense = await client.ValidateLicenseAsync(validateRequestMissingLicense);

    Console.WriteLine(validateResultMissingLicense.Success ? "License is valid." : "There is no valid license.");
}