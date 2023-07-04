using Application.CreateLicense;
using Application.ValidateLicense;
using Grpc.Core;
using MediatR;

namespace API.Services
{
    public class LicensorService : Licensor.LicensorBase
    {
        private readonly ISender _mediator;

        public LicensorService(ISender mediator)
        {
            _mediator = mediator;
        }

        public override async Task<CreateLicenseGrpcResponse> CreateLicense(CreateLicenseGrpcRequest grpcRequest, ServerCallContext context)
        {
            var request = new CreateLicenseRequest(grpcRequest.UserId, grpcRequest.Expires.ToDateTime());
            var result = await _mediator.Send(request, context.CancellationToken);
            var grpcResult = new CreateLicenseGrpcResponse { Success = result.Success };
            return grpcResult;
        }

        public override async Task<ValidateLicenseGrpcResponse> ValidateLicense(ValidateLicenseGrpcRequest grpcRequest, ServerCallContext context)
        {
            var request = new ValidateLicenseRequest(grpcRequest.UserId);
            var result = await _mediator.Send(request, context.CancellationToken);
            var grpcResult = new ValidateLicenseGrpcResponse { Success = result.Success };
            return grpcResult;
        }
    }
}