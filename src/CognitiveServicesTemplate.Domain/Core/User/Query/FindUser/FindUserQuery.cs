using MediatR;
using CognitiveServicesTemplate.Common.ErrorHandling;
using OperationResult;

namespace CognitiveServicesTemplate.Domain.Core.User.Query.FindUser
{
    public class FindUserQuery : IRequest<Result<Entity.User, Error>>
    {
        public string UserId { get; set; }
    }
}