using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Web.ChainOfResponsibility.ChainOfResponsibility
{
    public class SendEmailProcessHandler : ProcessHandler
    {
        private readonly string _email;
        private readonly string _fileName;
        private readonly ILogger _logger;



        public SendEmailProcessHandler(string email, string fileName, ILogger logger)
        {
            _email = email;
            _fileName = fileName;
            _logger = logger;
        }

        public override object Handle(object o)
        {
            //var mailMessage = new MailMessage();
            //var smtpClient = new SmtpClient("");

            //mailMessage.From = new MailAddress("");
            //mailMessage.To.Add(new MailAddress(_email));
            //mailMessage.Subject = "User created";

            //mailMessage.Body = "<p>Test test</p>";

            //mailMessage.IsBodyHtml = true;


            //Attachment attachment = new Attachment(o as MemoryStream, _fileName, MediaTypeNames.Application.Zip);
            //mailMessage.Attachments.Add(attachment);

            //smtpClient.Port = 555;
            //smtpClient.Credentials = new NetworkCredential("test@gmail.com", "password");
            //smtpClient.Send(mailMessage);

            _logger.LogInformation("Mail test");

            return base.Handle(null);
        }
    }
}
