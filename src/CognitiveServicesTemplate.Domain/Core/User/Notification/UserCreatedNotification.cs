using MediatR;

namespace CognitiveServicesTemplate.Domain.Core.User.Notification
{
    public class UserCreatedNotification : INotification
    {
        public string UserId { get; set; }
    }
}