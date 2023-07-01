using Grpc.Net.Client;
using Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7024");
var client = new Greeter.GreeterClient(channel);

var request = new HelloRequest { Name = "Michal" };
var result = await client.SayHelloAsync(request);

Console.WriteLine(result?.Message);