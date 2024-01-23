using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;

namespace Business_Logic_Layer.IServices
{
    public interface ISeekerProfileService
    {
        Task<SeekerProfile> GetSeekerProfile(int userAccountId);
        Task<EmailInvite> CreateInterviewInvite(EmailInvite invite);
        Task<ICollection<SeekerProfile>> GetAllSeekerProfiles();
        Task<ICollection<EmailInvite>> GetInterviewsById(int userId);
        Task<SeekerProfile> CreateSeekerProfile(SeekerProfile seekerProfile);
        Task<SeekerProfile> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile);
        Task<string> DeleteSeekerProfile(int userAccountId);
    }
}
