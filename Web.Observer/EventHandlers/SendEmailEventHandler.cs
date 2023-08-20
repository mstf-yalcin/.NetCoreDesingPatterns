using MediatR;
using Web.Observer.Events;

namespace Web.Observer.EventHandlers
{
    public class SendEmailEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<SendEmailEventHandler> _logger;

        public SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {


            //var mailMessage = new MailMessage();
            //var smtpClient = new SmtpClient("");

            //mailMessage.From = new MailAddress("");
            //mailMessage.To.Add(new MailAddress(appUser.Email));
            //mailMessage.Subject = "User created";

            //mailMessage.Body = "<p>Test test</p>";

            //mailMessage.IsBodyHtml = true;

            //smtpClient.Port = 555;
            //smtpClient.Credentials = new NetworkCredential("test@gmail.com", "password");
            //smtpClient.Send(mailMessage);

            _logger.LogInformation("Email was send to user:" + notification.AppUser.Id);

            return Task.CompletedTask;
        }
    }
}
