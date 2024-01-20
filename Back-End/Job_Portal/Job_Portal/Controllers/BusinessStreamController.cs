using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

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
            var res = await _businessStreamService.GetBusinessStream(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _businessStreamService.GetAllBusinessStreams();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBusinessStream(BusinessStream businessStream)
        {
            var res = await _businessStreamService.CreateBusinessStream(businessStream);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBusinessStream(BusinessStream updatedBusinessStream)
        {
            var res = await _businessStreamService.UpdateBusinessStream(updatedBusinessStream);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusinessStream(int id)
        {
            var res = await _businessStreamService.DeleteBusinessStream(id);
            return Ok(res);
        }
    }
}
