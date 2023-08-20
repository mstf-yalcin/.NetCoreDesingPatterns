using BaseProject.Models;
using System.Net;
using System.Net.Mail;

namespace Web.Observer.Observers
{
    public class UserObserverSendMail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>();

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

            logger.LogInformation("Email was send to user:" + appUser.Id);
        }
    }
}
