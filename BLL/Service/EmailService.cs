using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    class EmailService
    {
        public async Task SendEmailAsync(string email, string subject)
        {
            var emailMessage = new MimeMessage();
            
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "main@example.com"));
            emailMessage.To.Add(new MailboxAddress("Happy Buyer", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "You by tickie"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("klecz.anastasia@gmail.com", "hades31337");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
