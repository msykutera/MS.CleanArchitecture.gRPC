using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CreateLicense
{
    public record CreateLicenseRequest(string UserId, DateTime Expires) : IRequest<CreateLicenseResponse>;
}
