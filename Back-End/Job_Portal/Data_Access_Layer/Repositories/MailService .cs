
using Data_Access_Layer.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Data_Access_Layer.Repositories
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }

        public string SendEmail(string toEmail)
        {
            string fromMail = "itzhirings@gmail.com";
            string fromPassword = "kywarwgunmvtolrg";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "ItzHirings - Registration Successful";
            message.To.Add(new MailAddress(toEmail));

            string registrationMessage = "<html><body>" +
                                        "<h2>Welcome to ItzHirings!</h2>" +
                                        "<p>Thank you for registering. Your temporary password is: <a><strong>{temporaryPassword}</strong></a></p>" +
                                        "<p>Please login using this temporary password after your account verification and change it for security reasons.</p>" +
                                        "</body></html>";

            
            string temporaryPassword = GenerateRandomAlphanumericPassword(10); 

           
            registrationMessage = registrationMessage.Replace("{temporaryPassword}", temporaryPassword);

            message.Body = registrationMessage;
            message.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
            return temporaryPassword;
        }

        private static string GenerateRandomAlphanumericPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }


        public string SendverificationEmail(string toEmail)
        {
            string fromMail = "itzhirings@gmail.com";
            string fromPassword = "kywarwgunmvtolrg";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "ItzHirings - Account verification Successful";
            message.To.Add(new MailAddress(toEmail));

            // registration message template
            string registrationMessage = "<html><body>" +
                                        "<h2>Welcome to ItzHirings!</h2>" +
                                        "<h3>Thank you for registering</h3>" +
                                        "<h4>Your account has been verified.</h4>" +
                                        "<p>Please login using your temperory password that we sent you while ur registration</p>"+
                                        "</body></html>";  

            message.Body = registrationMessage;
            message.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
            return "Mail sent";
        }

        public string SendFeedbackEmail(string toEmail, string feedback)
        {
            string fromMail = "itzhirings@gmail.com";
            string fromPassword = "kywarwgunmvtolrg";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "ItzHirings - Feedback";
            message.To.Add(new MailAddress(toEmail));

            // registration message template
            string registrationMessage = "<html><body>" +
                                        "<h2>Feedback from ItzHirings!</h2>" +
                                        "<h3>Feedback - {feedMsg}</h3>" +
                                        "<h4>Your account has been Rejected.</h4>" +
                                        "<p>Sorry for you inconvience, Please go through the feedback message and try again.</p>" +
                                        "</body></html>";

            registrationMessage = registrationMessage.Replace("{feedMsg}", feedback);
            message.Body = registrationMessage;
            message.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
            return "Mail sent";
        }
    }
}
