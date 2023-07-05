using Grpc.Net.Client;
using Client;

try
{
    var startup = new Startup();

    using var channel = GrpcChannel.ForAddress(startup.ApiSettings.Url);
    var grpcClient = new Licensor.LicensorClient(channel);

    var client = new LicenseClient(grpcClient);

    await client.CreateLicense();
    await client.ValidateLicense();
    await client.ValidateMissingLicense();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error occured. {ex.Message}");
}

