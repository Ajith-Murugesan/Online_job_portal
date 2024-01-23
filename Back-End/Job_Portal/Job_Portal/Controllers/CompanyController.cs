using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("Company/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _companyService.GetCompany(id);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompanyByEmployeer(int id)
        {
            var res = await _companyService.GetCompanyByEmployeer(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _companyService.GetAllCompanies();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany(Company company)
        {
            var res = await _companyService.CreateCompany(company);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCompany(Company updatedCompany)
        {
            var res = await _companyService.UpdateCompany(updatedCompany);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var res = await _companyService.DeleteCompany(id);
            return Ok(res);
        }
    }
}
