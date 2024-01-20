using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface IExperienceDetailsService
    {
        Task<ExperienceDetails> GetExperienceDetails(int userAccountId);
        Task<ICollection<ExperienceDetails>> GetAllExperienceDetails();
        Task<ExperienceDetails> CreateExperienceDetails(ExperienceDetails experienceDetails);
        Task<ExperienceDetails> UpdateExperienceDetails(ExperienceDetails updatedExperienceDetails);
        Task<string> DeleteExperienceDetails(int userAccountId);
    }
}
