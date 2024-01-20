using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class SkillsetService : ISkillsetService
    {
        private readonly ISkillsetRepository _skillsetRepository;

        public SkillsetService(ISkillsetRepository skillsetRepository)
        {
            _skillsetRepository = skillsetRepository;
        }

        public async Task<Skillset> GetSkillset(int skillsetId)
        {
            return await _skillsetRepository.GetSkillset(skillsetId);
        }

        public async Task<ICollection<Skillset>> GetAllSkillsets()
        {
            return await _skillsetRepository.GetAllSkillsets();
        }

        public async Task<Skillset> CreateSkillset(Skillset skillset)
        {
            return await _skillsetRepository.CreateSkillset(skillset);
        }

        public async Task<Skillset> UpdateSkillset(Skillset updatedSkillset)
        {
            return await _skillsetRepository.UpdateSkillset(updatedSkillset);
        }

        public async Task<string> DeleteSkillset(int skillsetId)
        {
            return await _skillsetRepository.DeleteSkillset(skillsetId);
        }
    }
}
