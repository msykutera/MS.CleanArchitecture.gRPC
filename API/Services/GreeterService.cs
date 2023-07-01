using Application.CreateLicense;
using Grpc.Core;
using MediatR;

namespace API.Services
{
    public class GreeterService : Licensor.LicensorBase
    {
        private readonly ISender _mediator;

        public GreeterService(ISender mediator)
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
    }
}