using Microsoft.Extensions.Configuration;

namespace Client
{
    internal class Startup
    {
        public ApiSettings ApiSettings { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build(); 
            
            ApiSettings = config.GetSection("ApiSettings").Get<ApiSettings>() ?? throw new Exception("API configuration is missing");
        }
    }
}
