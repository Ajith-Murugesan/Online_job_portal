using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface ISkillsetRepository
    {
        Task<Skillset> GetSkillset(int skillsetId);
        Task<ICollection<Skillset>> GetAllSkillsets();
        Task<Skillset> CreateSkillset(Skillset skillset);
        Task<Skillset> UpdateSkillset(Skillset updatedSkillset);
        Task<string> DeleteSkillset(int skillsetId);
    }
}
