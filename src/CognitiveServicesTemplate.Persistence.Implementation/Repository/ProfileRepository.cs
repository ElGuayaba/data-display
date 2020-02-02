using Microsoft.EntityFrameworkCore;
using CognitiveServicesTemplate.Domain.Entity;
using CognitiveServicesTemplate.Persistence.Contract.Repository;
using CognitiveServicesTemplate.Persistence.Implementation.Context;

namespace CognitiveServicesTemplate.Persistence.Implementation.Repository
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(CognitiveServicesTemplateDbContext dbContext) : base(dbContext)
        {
        }
    }
}