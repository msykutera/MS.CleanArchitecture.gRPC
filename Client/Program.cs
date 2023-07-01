using Grpc.Net.Client;
using Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7024");
var client = new Licensor.LicensorClient(channel);

var request = new CreateLicenseGrpcRequest { UserId = "Michal", Expires = new Google.Protobuf.WellKnownTypes.Timestamp() };
var result = await client.CreateLicenseAsync(request);

Console.WriteLine(result.Success ? "License created succesfully." : "Failed to create license.");