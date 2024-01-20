using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface ISeekerProfileRepository
    {
        Task<SeekerProfile> GetSeekerProfile(int userAccountId);
        Task<ICollection<SeekerProfile>> GetAllSeekerProfiles();
        Task<SeekerProfile> CreateSeekerProfile(SeekerProfile seekerProfile);
        Task<SeekerProfile> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile);
        Task<string> DeleteSeekerProfile(int userAccountId);
    }
}
