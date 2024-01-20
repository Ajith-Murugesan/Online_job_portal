using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IEducationalDetails
    {
        Task<EducationalDetails> GetEducationalDetails(int userAccountId);
        Task<ICollection<EducationalDetails>> GetAllEducationalDetails();
        Task<EducationalDetails> CreateEducationalDetails(EducationalDetails educationalDetails);
        Task<EducationalDetails> UpdateEducationalDetails(EducationalDetails updatedEducationalDetails);
        Task<string> DeleteEducationalDetails(int userAccountId);
    }
}
