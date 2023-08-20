using MediatR;
using Web.Observer.Events;

namespace Web.Observer.EventHandlers
{
    public class CreatedUserWriteToConsoleEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<CreatedUserWriteToConsoleEventHandler> _logger;


        public CreatedUserWriteToConsoleEventHandler(ILogger<CreatedUserWriteToConsoleEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("user created:" + notification.AppUser.Id);
            return Task.CompletedTask;
        }
    }
}
