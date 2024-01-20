using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface ISkillsetService
    {
        Task<Skillset> GetSkillset(int skillsetId);
        Task<ICollection<Skillset>> GetAllSkillsets();
        Task<Skillset> CreateSkillset(Skillset skillset);
        Task<Skillset> UpdateSkillset(Skillset updatedSkillset);
        Task<string> DeleteSkillset(int skillsetId);
    }
}
