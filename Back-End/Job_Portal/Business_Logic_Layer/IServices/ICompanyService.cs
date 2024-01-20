using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface ICompanyService
    {
        Task<Company> GetCompany(int companyId);
        Task<ICollection<Company>> GetAllCompanies();
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company updatedCompany);
        Task<string> DeleteCompany(int companyId);
    }
}
