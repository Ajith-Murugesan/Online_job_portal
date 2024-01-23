
using Data_Access_Layer.ViewModels;

namespace Data_Access_Layer.Interfaces
{
    public interface IMailService
    {
        string SendEmail(string  toEmail);
        string SendverificationEmail(string toEmail);
        string SendFeedbackEmail(string toEmail,string message);
        EmailInvite SendInviteEmail(string toEmail, EmailInvite invite);
    }
}
