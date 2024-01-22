using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IUserAccount
    {
        Task<UserAccount> GetAccount(int id);
        Task<UserAccount> GetUser(Login usr);
        Task<ICollection<UserAccount>> GetAllUsers();
        Task<RegisterUser> CreateAccount(RegisterUser account);
        Task<UserAccount> UpdateAccount(UserAccount updatedAccount);
        Task<UpdateUserStatusResponse> DeleteAccount(DeleteInfo deleteInfo);
        Task<UpdateUserStatusResponse> UpdateUserStatus(UpdateUserStatus status);
        Task<ResetPassword> ResetPassword(ResetPassword password);
    }
}
