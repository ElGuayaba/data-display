using Microsoft.EntityFrameworkCore;
using CognitiveServicesTemplate.Domain.Entity;
using CognitiveServicesTemplate.Persistence.Contract.Repository;
using CognitiveServicesTemplate.Persistence.Implementation.Context;

namespace CognitiveServicesTemplate.Persistence.Implementation.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CognitiveServicesTemplateDbContext dbContext) : base(dbContext)
        {
        }
    }
}