using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int companyId);
        Task<ICollection<Company>> GetAllCompanies();
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company updatedCompany);
        Task<string> DeleteCompany(int companyId);
    }
}
