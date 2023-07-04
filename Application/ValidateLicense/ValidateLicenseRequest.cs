using MediatR;

namespace Application.ValidateLicense;

public record ValidateLicenseRequest(string UserId) : IRequest<ValidateLicenseResponse>;
