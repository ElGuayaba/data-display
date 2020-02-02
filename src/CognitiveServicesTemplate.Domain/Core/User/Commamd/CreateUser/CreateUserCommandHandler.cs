using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using CognitiveServicesTemplate.Domain.Core.User.Notification;
using CognitiveServicesTemplate.Persistence.Contract;

namespace CognitiveServicesTemplate.Domain.Core.User.Commamd.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {      
        
        protected readonly ILogger<CreateUserCommandHandler> Logger;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMediator Mediator;
        
        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUnitOfWork unitOfWork, IMediator mediator)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            Mediator = mediator;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToUserEntity();

            await UnitOfWork.UserRepository.Insert(user);

            try
            {
                await UnitOfWork.SaveAsync(cancellationToken);

                await Mediator.Publish(new UserCreatedNotification
                {
                    UserId = user.Id
                }, cancellationToken);
                
                Logger.LogInformation("Created user with id {@UserId}.", user.Id);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error creating a new user with id {@UserId}.", request.UserId);
            }
            
            return Unit.Value;
        }
    }
}