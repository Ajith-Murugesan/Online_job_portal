using Business_Logic_Layer.IServices;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class UserAccountService: IUserAccountService
    {
        private readonly IUserAccount _userAccount;

        public UserAccountService(IUserAccount userAccount)
        {
            _userAccount = userAccount;
        }

        public async Task<UserAccount> GetAccount(int id)
        {
            return await _userAccount.GetAccount(id);
        }

        public async Task<ICollection<UserAccount>> GetAllUsers()
        {
            return await _userAccount.GetAllUsers();
        }

        public async Task<RegisterUser> CreateAccount(RegisterUser account)
        {
            return await _userAccount.CreateAccount(account);
        }
        public async Task<UserAccount> UpdateAccount(UserAccount updatedAccount)
        {
            return await _userAccount.UpdateAccount(updatedAccount);
        }

        public async Task<UpdateUserStatusResponse> DeleteAccount(DeleteInfo deleteInfo)
        {
            return await _userAccount.DeleteAccount(deleteInfo);
        }
        public async Task<UpdateUserStatusResponse> UpdateUserStatus(UpdateUserStatus status)
        {
            return await _userAccount.UpdateUserStatus(status);
        }

        public async Task<ResetPassword> ResetPassword(ResetPassword password)
        {
            return await _userAccount.ResetPassword(password);
        }

        public async Task<UserAccount> GetUser(Login usr)
        {
            return await _userAccount.GetUser(usr);
        }

        public async Task<ICollection<JobApplication>> GetJobApplicationById(int id)
        {
            return await _userAccount.GetJobApplicationById(id);
        }
    }
}
