using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.IServices
{
    public interface IUserAccountService
    {
        Task<UserAccount> GetAccount(int id);
        Task<ICollection<UserAccount>> GetAllUsers();
        Task<RegisterUser> CreateAccount(RegisterUser account);
        Task<UserAccount> UpdateAccount(UserAccount updatedAccount);
        Task<string> DeleteAccount(int userId);
        Task<string> UpdateUserStatus(int id);
        Task<ResetPassword> ResetPassword(ResetPassword password);
    }
}
