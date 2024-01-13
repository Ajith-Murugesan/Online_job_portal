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
        Task<ICollection<UserAccount>> GetAllUsers();
        Task<UserAccount> CreateAccount(UserAccount account);
        Task<UserAccount> UpdateAccount(UserAccount updatedAccount);
        Task<string> DeleteAccount(int userId);
    }
}
