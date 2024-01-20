using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class SeekerProfileService : ISeekerProfileService
    {
        private readonly ISeekerProfileRepository _seekerProfileRepository;

        public SeekerProfileService(ISeekerProfileRepository seekerProfileRepository)
        {
            _seekerProfileRepository = seekerProfileRepository;
        }

        public async Task<SeekerProfile> GetSeekerProfile(int userAccountId)
        {
            return await _seekerProfileRepository.GetSeekerProfile(userAccountId);
        }

        public async Task<ICollection<SeekerProfile>> GetAllSeekerProfiles()
        {
            return await _seekerProfileRepository.GetAllSeekerProfiles();
        }

        public async Task<SeekerProfile> CreateSeekerProfile(SeekerProfile seekerProfile)
        {
            return await _seekerProfileRepository.CreateSeekerProfile(seekerProfile);
        }

        public async Task<SeekerProfile> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile)
        {
            return await _seekerProfileRepository.UpdateSeekerProfile(updatedSeekerProfile);
        }

        public async Task<string> DeleteSeekerProfile(int userAccountId)
        {
            return await _seekerProfileRepository.DeleteSeekerProfile(userAccountId);
        }
    }
}
