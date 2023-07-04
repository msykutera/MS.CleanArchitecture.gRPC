using Application.Common;
using Domain;
using MediatR;

namespace Application.CreateLicense
{
    public class CreateLicenseHandler : IRequestHandler<CreateLicenseRequest, CreateLicenseResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateLicenseHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateLicenseResponse> Handle(CreateLicenseRequest request, CancellationToken cancellationToken)
        {
            var license = new License(0, request.UserId, request.Expires);

            _dbContext.Licenses.Add(license);

            var dbResult = await _dbContext.SaveChangesAsync(cancellationToken);
            var result = new CreateLicenseResponse(dbResult > 0);
            return result;
        }
    }
}