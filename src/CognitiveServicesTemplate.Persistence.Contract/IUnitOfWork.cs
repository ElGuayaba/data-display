using System.Threading;
using System.Threading.Tasks;
using CognitiveServicesTemplate.Persistence.Contract.Repository;

namespace CognitiveServicesTemplate.Persistence.Contract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
        IProfileRepository ProfileRepository { get; set; }
        
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}