using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace AspNetIdentity.WebApi.Services
{
    public class EmailService : IIdentityMessageService
    {

        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridAsync(message);
        }

        private Task configSendGridAsync(IdentityMessage message)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress("pdench@denchconsulting.com", "To Name"));
                message.From = new MailAddress("pfdench@gmail.com");
                message.Subject = "SendGrid Message";
                string text = "text body";
                string html = @"<p>html body</p>";

                message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient client = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("pdench", "cAssius5");
                client.Credentials = credentials;
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}