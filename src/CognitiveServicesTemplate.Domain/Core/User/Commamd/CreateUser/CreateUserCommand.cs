using MediatR;

namespace CognitiveServicesTemplate.Domain.Core.User.Commamd.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}