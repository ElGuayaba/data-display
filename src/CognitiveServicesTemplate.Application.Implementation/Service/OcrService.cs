using CognitiveServicesTemplate.Application.Contract.Service;
using CognitiveServicesTemplate.Common.ErrorHandling;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Threading;
using System.Threading.Tasks;
using static OperationResult.Helpers;

namespace CognitiveServicesTemplate.Application.Implementation.Service
{
	public class OcrService : IUserService
    {
        protected readonly ILogger<OcrService> Logger;
        protected readonly IMediator Mediator;

        public OcrService(ILogger<OcrService> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        public async Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default)
        {
            return Ok();
        }
    }
}