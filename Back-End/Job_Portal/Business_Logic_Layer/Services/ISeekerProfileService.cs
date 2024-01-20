using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface ISeekerProfileService
    {
        Task<SeekerProfile> GetSeekerProfile(int userAccountId);
        Task<ICollection<SeekerProfile>> GetAllSeekerProfiles();
        Task<SeekerProfile> CreateSeekerProfile(SeekerProfile seekerProfile);
        Task<SeekerProfile> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile);
        Task<string> DeleteSeekerProfile(int userAccountId);
    }
}
