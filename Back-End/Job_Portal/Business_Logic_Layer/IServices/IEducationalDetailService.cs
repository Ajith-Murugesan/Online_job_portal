using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.IServices
{
    public interface IEducationalDetailService
    {
        Task<EducationalDetails> GetEducationalDetails(int userAccountId);
        Task<ICollection<EducationalDetails>> GetAllEducationalDetails();
        Task<EducationalDetails> CreateEducationalDetails(EducationalDetails educationalDetails);
        Task<EducationalDetails> UpdateEducationalDetails(EducationalDetails updatedEducationalDetails);
        Task<string> DeleteEducationalDetails(int userAccountId);

    }
}
