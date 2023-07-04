using Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ValidateLicense;

public class ValidateLicenseHandler : IRequestHandler<ValidateLicenseRequest, ValidateLicenseResponse>
{
    private readonly IApplicationDbContext _dbContext;

    public ValidateLicenseHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ValidateLicenseResponse> Handle(ValidateLicenseRequest request, CancellationToken cancellationToken)
    {
        var licenseExists = await _dbContext.Licenses.AnyAsync(x => x.UserId == request.UserId && x.Expires >= DateTime.UtcNow, cancellationToken);
        var result = new ValidateLicenseResponse(licenseExists);
        return result;
    }
}
