using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using CognitiveServicesTemplate.Common.ErrorHandling;
using OperationResult;
using static OperationResult.Helpers;
using static CognitiveServicesTemplate.Common.ErrorHandling.Helpers;

namespace CognitiveServicesTemplate.Domain.Core.User.Query.FindUser
{
    public class FindUserQueryHandler : IRequestHandler<FindUserQuery, Result<Entity.User, Error>>
    {
        protected readonly ILogger<FindUserQueryHandler> Logger;
        protected readonly ICognitiveServicesTemplateDbContext DbContext;

        public FindUserQueryHandler(ILogger<FindUserQueryHandler> logger, ICognitiveServicesTemplateDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public async Task<Result<Entity.User, Error>> Handle(FindUserQuery request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users.AsNoTracking()
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
            {
                return Error(NotFound($"User with Id: {request.UserId} was not found."));
            }

            return Ok(user);
        }
    }
}