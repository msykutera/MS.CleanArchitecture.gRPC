using API.Services;
using Application;
using Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGrpc();
        builder.Services.AddInfrastructureServices();
        builder.Services.AddApplicationServices();

        var app = builder.Build();

        app.MapGrpcService<LicensorService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

        app.Run();
    }
}