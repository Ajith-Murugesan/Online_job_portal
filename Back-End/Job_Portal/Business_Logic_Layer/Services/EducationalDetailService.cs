using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class EducationalDetailService : IEducationalDetailService
    {
        private readonly IEducationalDetails _educationalDetailsRepository;

        public EducationalDetailService(IEducationalDetails educationalDetailsRepository)
        {
            _educationalDetailsRepository = educationalDetailsRepository;
        }

        public async Task<EducationalDetails> GetEducationalDetails(int userAccountId)
        {
            return await _educationalDetailsRepository.GetEducationalDetails(userAccountId);
        }

        public async Task<ICollection<EducationalDetails>> GetAllEducationalDetails()
        {
            return await _educationalDetailsRepository.GetAllEducationalDetails();
        }

        public async Task<EducationalDetails> CreateEducationalDetails(EducationalDetails educationalDetails)
        {
            return await _educationalDetailsRepository.CreateEducationalDetails(educationalDetails);
        }

        public async Task<EducationalDetails> UpdateEducationalDetails(EducationalDetails updatedEducationalDetails)
        {
            return await _educationalDetailsRepository.UpdateEducationalDetails(updatedEducationalDetails);
        }

        public async Task<string> DeleteEducationalDetails(int userAccountId)
        {
            return await _educationalDetailsRepository.DeleteEducationalDetails(userAccountId);
        }
    }
}
