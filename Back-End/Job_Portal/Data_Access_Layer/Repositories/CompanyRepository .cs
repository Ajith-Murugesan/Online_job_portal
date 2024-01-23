using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;

namespace Data_Access_Layer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConfiguration _config;

        public CompanyRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Company> GetCompany(int companyId)
        {
            Company company = new Company();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT company_id, company_name, stream_id, company_description, website_url, company_image FROM company WHERE company_id = @CompanyId", con))
                {
                    cmd.Parameters.AddWithValue("@CompanyId", companyId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            company.CompanyId = reader.GetInt32(0);
                            company.CompanyName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            company.StreamId = reader.GetInt32(2);
                            company.CompanyDescription = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            company.WebsiteUrl = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            company.CompanyImage = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }
                }
            }

            return company;
        }

        public async Task<ICollection<Company>> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT company_id, company_name, stream_id, company_description, website_url, company_image FROM company", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        companies.Add(new Company
                        {
                            CompanyId = reader.GetInt32(0),
                            CompanyName = reader.IsDBNull(1) ? "" :reader.GetString(1),
                            StreamId = reader.GetInt32(2),
                            CompanyDescription = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            WebsiteUrl = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            CompanyImage = reader.IsDBNull(5)? ""  : reader.GetString(5)
                        });
                    }
                }
            }

            return companies;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO company (company_name, stream_id, company_description, website_url, company_image) VALUES (@CompanyName, @StreamId, @CompanyDescription, @WebsiteUrl, @CompanyImage);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    cmd.Parameters.AddWithValue("@StreamId", company.StreamId);
                    cmd.Parameters.AddWithValue("@CompanyDescription", company.CompanyDescription);
                    cmd.Parameters.AddWithValue("@WebsiteUrl", company.WebsiteUrl);
                    cmd.Parameters.AddWithValue("@CompanyImage", company.CompanyImage);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return company;
        }

        public async Task<Company> UpdateCompany(Company updatedCompany)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE company SET company_name = @CompanyName, stream_id = @StreamId, company_description = @CompanyDescription, website_url = @WebsiteUrl, company_image = @CompanyImage WHERE company_id = @CompanyId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CompanyId", updatedCompany.CompanyId);
                    cmd.Parameters.AddWithValue("@CompanyName", updatedCompany.CompanyName);
                    cmd.Parameters.AddWithValue("@StreamId", updatedCompany.StreamId);
                    cmd.Parameters.AddWithValue("@CompanyDescription", updatedCompany.CompanyDescription);
                    cmd.Parameters.AddWithValue("@WebsiteUrl", updatedCompany.WebsiteUrl);
                    cmd.Parameters.AddWithValue("@CompanyImage", updatedCompany.CompanyImage);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedCompany;
        }

        public async Task<string> DeleteCompany(int companyId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM company WHERE company_id = @CompanyId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CompanyId", companyId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "Company deleted successfully";
        }

        public async Task<Company> GetCompanyByEmployeer(int empId)
        {

            Company company = new Company();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT company_id, company_name, stream_id, company_description, website_url, company_image FROM company WHERE user_account_id = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", empId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            company.CompanyId = reader.GetInt32(0);
                            company.CompanyName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            company.StreamId = reader.GetInt32(2);
                            company.CompanyDescription = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            company.WebsiteUrl = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            company.CompanyImage = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }
                }
            }

            return company;
        }
    }
}
