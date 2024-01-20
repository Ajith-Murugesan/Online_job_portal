using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("Skillset/[action]")]
    [ApiController]
    public class SkillsetController : ControllerBase
    {
        private readonly ISkillsetService _skillsetService;

        public SkillsetController(ISkillsetService skillsetService)
        {
            _skillsetService = skillsetService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _skillsetService.GetSkillset(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _skillsetService.GetAllSkillsets();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSkillset(Skillset skillset)
        {
            var res = await _skillsetService.CreateSkillset(skillset);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSkillset(Skillset updatedSkillset)
        {
            var res = await _skillsetService.UpdateSkillset(updatedSkillset);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkillset(int id)
        {
            var res = await _skillsetService.DeleteSkillset(id);
            return Ok(res);
        }
    }
}
