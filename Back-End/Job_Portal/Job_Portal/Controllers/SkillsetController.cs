using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            try
            {
                var res = await _skillsetService.GetSkillset(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var res = await _skillsetService.GetAllSkillsets();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateSkillset(Skillset skillset)
        {
            try
            {
                var res = await _skillsetService.CreateSkillset(skillset);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSkillset(Skillset updatedSkillset)
        {
            try
            {
                var res = await _skillsetService.UpdateSkillset(updatedSkillset);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkillset(int id)
        {
            try
            {
                var res = await _skillsetService.DeleteSkillset(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
