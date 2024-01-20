using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class BusinessStreamService : IBusinessStreamService
    {
        private readonly IBusinessStreamRepository _businessStreamRepository;

        public BusinessStreamService(IBusinessStreamRepository businessStreamRepository)
        {
            _businessStreamRepository = businessStreamRepository;
        }

        public async Task<BusinessStream> GetBusinessStream(int streamId)
        {
            return await _businessStreamRepository.GetBusinessStream(streamId);
        }

        public async Task<ICollection<BusinessStream>> GetAllBusinessStreams()
        {
            return await _businessStreamRepository.GetAllBusinessStreams();
        }

        public async Task<BusinessStream> CreateBusinessStream(BusinessStream businessStream)
        {
            return await _businessStreamRepository.CreateBusinessStream(businessStream);
        }

        public async Task<BusinessStream> UpdateBusinessStream(BusinessStream updatedBusinessStream)
        {
            return await _businessStreamRepository.UpdateBusinessStream(updatedBusinessStream);
        }

        public async Task<string> DeleteBusinessStream(int streamId)
        {
            return await _businessStreamRepository.DeleteBusinessStream(streamId);
        }
    }
}
