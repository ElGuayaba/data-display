using DataDisplay.Application.Contract.Service;
using DataDisplay.Common.ErrorHandling;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Threading;
using System.Threading.Tasks;
using static OperationResult.Helpers;

namespace DataDisplay.Application.Implementation.Service
{
    public class OcrService : IUserService
    {
        protected readonly ILogger<OcrService> Logger;

        public OcrService(ILogger<OcrService> logger)
        {
            Logger = logger;
        }

        public async Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default)
        {
            return Ok();
        }
    }
}