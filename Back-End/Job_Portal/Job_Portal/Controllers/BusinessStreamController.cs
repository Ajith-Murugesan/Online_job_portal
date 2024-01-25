using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Job_Portal.Controllers
{
    [Route("BusinessStream/[action]")]
    [ApiController]
    public class BusinessStreamController : ControllerBase
    {
        private readonly IBusinessStreamService _businessStreamService;

        public BusinessStreamController(IBusinessStreamService businessStreamService)
        {
            _businessStreamService = businessStreamService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var res = await _businessStreamService.GetBusinessStream(id);
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
                var res = await _businessStreamService.GetAllBusinessStreams();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateBusinessStream(BusinessStream businessStream)
        {
            try
            {
                var res = await _businessStreamService.CreateBusinessStream(businessStream);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBusinessStream(BusinessStream updatedBusinessStream)
        {
            try
            {
                var res = await _businessStreamService.UpdateBusinessStream(updatedBusinessStream);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusinessStream(int id)
        {
            try
            {
                var res = await _businessStreamService.DeleteBusinessStream(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
