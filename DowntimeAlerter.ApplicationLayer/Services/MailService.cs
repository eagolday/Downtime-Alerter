using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.ApplicationLayer.Services {


    public class MailService : IEmailSender {
       
       
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress
                                        ("From DowntimeAlerter",
                                         "emrullahagolday@gmail.com"
                                         ));
                message.To.Add(new MailboxAddress("Error Url",
                                         email
                                         ));
                message.Subject = subject;  
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = htmlMessage
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(
                        "myname@gmail.com",
                        "pass"
                        );
                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
            }
            catch (System.Exception)
            {

                throw;
            }

           
        }
    }
}
