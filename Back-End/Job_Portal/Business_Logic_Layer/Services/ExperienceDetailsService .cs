using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class ExperienceDetailsService : IExperienceDetailsService
    {
        private readonly IExperienceDetailsRepository _experienceDetailsRepository;

        public ExperienceDetailsService(IExperienceDetailsRepository experienceDetailsRepository)
        {
            _experienceDetailsRepository = experienceDetailsRepository;
        }

        public async Task<ExperienceDetails> GetExperienceDetails(int userAccountId)
        {
            return await _experienceDetailsRepository.GetExperienceDetails(userAccountId);
        }

        public async Task<ICollection<ExperienceDetails>> GetAllExperienceDetails()
        {
            return await _experienceDetailsRepository.GetAllExperienceDetails();
        }

        public async Task<ExperienceDetails> CreateExperienceDetails(ExperienceDetails experienceDetails)
        {
            return await _experienceDetailsRepository.CreateExperienceDetails(experienceDetails);
        }

        public async Task<ExperienceDetails> UpdateExperienceDetails(ExperienceDetails updatedExperienceDetails)
        {
            return await _experienceDetailsRepository.UpdateExperienceDetails(updatedExperienceDetails);
        }

        public async Task<string> DeleteExperienceDetails(int userAccountId)
        {
            return await _experienceDetailsRepository.DeleteExperienceDetails(userAccountId);
        }
    }
}
