using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;

namespace Data_Access_Layer.Interfaces
{
    public interface ISeekerProfileRepository
    {
        Task<SeekerProfile> GetSeekerProfile(int userAccountId);
        Task<ICollection<SeekerProfile>> GetAllSeekerProfiles();
        Task<SeekerProfile> CreateSeekerProfile(SeekerProfile seekerProfile);

        Task<EmailInvite> CreateInterviewInvite(EmailInvite invite);
        Task<ICollection<EmailInvite>> GetInterviewsById(int userId);
        Task<SeekerProfile> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile);
        Task<string> DeleteSeekerProfile(int userAccountId);
    }
}
