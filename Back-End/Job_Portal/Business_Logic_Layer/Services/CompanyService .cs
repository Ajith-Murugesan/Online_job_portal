using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using System.ComponentModel.Design;

namespace Business_Logic_Layer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await _companyRepository.GetCompany(companyId);
        }

        public async Task<ICollection<Company>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanies();
        }

        public async Task<Company> CreateCompany(Company company)
        {
            return await _companyRepository.CreateCompany(company);
        }

        public async Task<Company> UpdateCompany(Company updatedCompany)
        {
            return await _companyRepository.UpdateCompany(updatedCompany);
        }

        public async Task<string> DeleteCompany(int companyId)
        {
            return await _companyRepository.DeleteCompany(companyId);
        }

        public async Task<Company> GetCompanyByEmployeer(int empId)
        {
            return await _companyRepository.GetCompanyByEmployeer(empId);
        }
    }
}
