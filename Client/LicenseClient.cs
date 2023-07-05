using Google.Protobuf.WellKnownTypes;

namespace Client
{
    internal class LicenseClient
    {
        private readonly Licensor.LicensorClient _client;

        public LicenseClient(Licensor.LicensorClient client)
        {
            _client = client;
        }

        public async Task CreateLicense()
        {
            var expires = DateTime.UtcNow.AddDays(1);
            var createRequest = new CreateLicenseGrpcRequest { UserId = "Michal", Expires = Timestamp.FromDateTime(expires) };
            var createResult = await _client.CreateLicenseAsync(createRequest);

            Console.WriteLine(createResult.Success ? "License created succesfully." : "Failed to create license.");
        }

        public async Task ValidateLicense()
        {
            var validateRequest = new ValidateLicenseGrpcRequest { UserId = "Michal" };
            var validateResult = await _client.ValidateLicenseAsync(validateRequest);

            Console.WriteLine(validateResult.Success ? "License is valid." : "There is no valid license.");
        }

        public async Task ValidateMissingLicense()
        {
            var validateRequestMissingLicense = new ValidateLicenseGrpcRequest { UserId = "Missing" };
            var validateResultMissingLicense = await _client.ValidateLicenseAsync(validateRequestMissingLicense);

            Console.WriteLine(validateResultMissingLicense.Success ? "License is valid." : "There is no valid license.");
        }
    }
}
