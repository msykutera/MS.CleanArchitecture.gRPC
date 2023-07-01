using MediatR;

namespace Application.CreateLicense
{
    public class CreateLicenseHandler : IRequestHandler<CreateLicenseRequest, CreateLicenseResponse>
    {
        public Task<CreateLicenseResponse> Handle(CreateLicenseRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateLicenseResponse { Success = true });
        }
    }
}