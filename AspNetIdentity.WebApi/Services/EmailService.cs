using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;

namespace AspNetIdentity.WebApi.Services
{
    public class EmailService : IIdentityMessageService
    {

        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridAsync(message);
        }

        private async Task configSendGridAsync(IdentityMessage message)
        {
            try
            {

                string apiKey = ConfigurationManager.AppSettings["sendgridkey"];
                dynamic sg = new SendGridAPIClient(apiKey);

                Email from = new Email("test@example.com");
                String subject = message.Subject;
                Email to = new Email("pfdench@gmail.com");
                Content content = new Content("text/html", message.Body);
                Mail mail = new Mail(from, subject, to, content);

                dynamic response = sg.client.mail.send.post(requestBody: mail.Get());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}