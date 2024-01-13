using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Interfaces
{
    public interface IMailService
    {
        void SendEmail(EmailDto request);
    }
}
