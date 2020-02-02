using System.Threading;
using System.Threading.Tasks;
using DataDisplay.Common.ErrorHandling;
using OperationResult;

namespace DataDisplay.Application.Contract.Service
{
    public interface IUserService
    {
        Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default);
    }
}