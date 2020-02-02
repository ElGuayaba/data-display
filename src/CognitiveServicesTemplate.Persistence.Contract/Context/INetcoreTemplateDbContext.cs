using Microsoft.EntityFrameworkCore;
using CognitiveServicesTemplate.Domain.Entity;

namespace CognitiveServicesTemplate.Persistence.Contract.Context
{
    public interface ICognitiveServicesTemplateDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Profile> Profiles { get; set; }
    }
}