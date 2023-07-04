using MediatR;

namespace Application.CreateLicense;

public record CreateLicenseRequest(string UserId, DateTime Expires) : IRequest<CreateLicenseResponse>;
