using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface IExperienceDetailsRepository
    {
        Task<ExperienceDetails> GetExperienceDetails(int userAccountId);
        Task<ICollection<ExperienceDetails>> GetAllExperienceDetails();
        Task<ExperienceDetails> CreateExperienceDetails(ExperienceDetails experienceDetails);
        Task<ExperienceDetails> UpdateExperienceDetails(ExperienceDetails updatedExperienceDetails);
        Task<string> DeleteExperienceDetails(int userAccountId);
    }
}
