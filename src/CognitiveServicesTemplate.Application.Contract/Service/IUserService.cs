using System.Threading;
using System.Threading.Tasks;
using CognitiveServicesTemplate.Common.ErrorHandling;
using OperationResult;

namespace CognitiveServicesTemplate.Application.Contract.Service
{
    public interface IUserService
    {
        Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default);
    }
}