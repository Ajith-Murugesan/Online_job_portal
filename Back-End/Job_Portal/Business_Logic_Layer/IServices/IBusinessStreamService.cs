using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.IServices
{
    public interface IBusinessStreamService
    {
        Task<BusinessStream> GetBusinessStream(int streamId);
        Task<ICollection<BusinessStream>> GetAllBusinessStreams();
        Task<BusinessStream> CreateBusinessStream(BusinessStream businessStream);
        Task<BusinessStream> UpdateBusinessStream(BusinessStream updatedBusinessStream);
        Task<string> DeleteBusinessStream(int streamId);
    }
}
