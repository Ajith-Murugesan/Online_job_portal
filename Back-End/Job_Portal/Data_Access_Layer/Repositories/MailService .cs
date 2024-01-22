
using Data_Access_Layer.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using Data_Access_Layer.ViewModels;

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

            
            string temporaryPassword = GenerateRandomAlphanumericPassword(15); 

           
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

        public string SendInviteEmail(string toEmail, EmailInvite invite)
        {
            string fromMail = "itzhirings@gmail.com";
            string fromPassword = "kywarwgunmvtolrg";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "ItzHirings - Interview Invite";
            message.To.Add(new MailAddress(toEmail));
            EmailInvite invites = new EmailInvite
            {
                CompanyName = invite.CompanyName,
                JobPosition = invite.JobPosition,
                InterviewDate = invite.InterviewDate,
                InterviewTime = invite.InterviewTime,
                LocationName = invite.LocationName
            };
            // registration message template
            string registrationMessage = "<html><body>" +
                                        "<h2>Interview Invitation from ItzHirings!</h2>" +
                                        "<h3>Company Name - {cmpname}</h3>" +
                                        "<h4>Your account has been Rejected.</h4>" +
                                        "<p>Sorry for you inconvience, Please go through the feedback message and try again.</p>" +
                                        "</body></html>";
            string emailTemplate = @"
            <!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Interview Invitation</title>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        margin: 0;
                        padding: 0;
                        background-color: #f4f4f4;
                        text-align: center;
                    }

                    .container {
                        max-width: 600px;
                        margin: 20px auto;
                        background-color: #fff;
                        padding: 20px;
                        border-radius: 8px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }

                    h2 {
                        color: #333;
                    }

                    p {
                        color: #555;
                    }

                    .footer {
                        margin-top: 20px;
                        color: #888;
                    }
                </style>
            </head>
            <body>
                <div class=""container"">
                    <h2>Interview Invitation</h2>
                    <p>You are invited for an interview at:</p>
                    <p><strong>{CompanyName}</strong></p>
                    <p>Position: <strong>{JobPosition}</strong></p>
                    <p>Date: <strong>{InterviewDate:yyyy-MM-dd}</strong></p>
                    <p>Time: <strong>{InterviewTime:hh:mm tt}</strong></p>
                    <p>Location: <strong>{LocationName}</strong></p>
                    <p>We look forward to seeing you there!</p>
                    <div class=""footer"">
                        <p>Best regards,<br>Your Company</p>
                    </div>
                </div>
            </body>
            </html>
        ";

            emailTemplate = emailTemplate
            .Replace("{CompanyName}", invite.CompanyName)
            .Replace("{JobPosition}", invite.JobPosition)
            .Replace("{InterviewDate}", invite.InterviewDate.ToString())
            .Replace("{InterviewTime}", invite.InterviewTime.ToString())
            .Replace("{LocationName}", invite.LocationName);
            message.Body = emailTemplate;
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
