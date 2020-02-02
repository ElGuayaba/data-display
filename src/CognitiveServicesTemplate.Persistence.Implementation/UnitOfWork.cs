using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CognitiveServicesTemplate.Persistence.Contract;
using CognitiveServicesTemplate.Persistence.Contract.Repository;
using CognitiveServicesTemplate.Persistence.Implementation.Context;

namespace CognitiveServicesTemplate.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CognitiveServicesTemplateDbContext Context;
        protected readonly ILogger<UnitOfWork> Logger;
        private bool _disposed;
        
        public IUserRepository UserRepository { get; set; }
        public IProfileRepository ProfileRepository { get; set; }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.SaveChangesAsync(cancellationToken);
                
                Logger.LogInformation("Database save operation finished correctly.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                Logger.LogError(e, "Database save operation failed, concurrency related.");

                throw;
            }
            catch (DbUpdateException e)
            {
                Logger.LogError(e, "Database save operation failed.");

                throw;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}