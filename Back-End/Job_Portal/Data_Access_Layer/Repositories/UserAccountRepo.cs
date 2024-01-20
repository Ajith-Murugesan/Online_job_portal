using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class UserAccountRepo : IUserAccount
    {
        private readonly IConfiguration _config;
        private readonly IMailService _mailService;
        public UserAccountRepo(IConfiguration configuration, IMailService mailService)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mailService = mailService;
        }

        public async Task<UserAccount> GetAccount(int id)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id FROM user_account WHERE user_account_id = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            userAccount.UserAccountId = reader.GetInt32(0);
                        }
                    }
                }
            }

            return userAccount;
        }

        public async Task<ICollection<UserAccount>> GetAllUsers()
        {
            List<UserAccount> users = new List<UserAccount>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, user_name, email, contact_number, is_active,user_type_id,password FROM user_account", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new UserAccount
                        {
                            UserAccountId = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            Email = reader.GetString(2),
                            ContactNumber = reader.IsDBNull(3) ? 00000000000 : reader.GetInt64(3),
                            IsActive = reader.IsDBNull(4) ? false : reader.GetBoolean(4),
                            UserTypeId=reader.IsDBNull(5) ? 0 :reader.GetInt32(5),
                            Password = reader.GetString(6),
                        });
                            
                    }
                }
            }

            return users;
        }



        public async Task<RegisterUser> CreateAccount(RegisterUser account)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO user_account (user_name,email,password,contact_number) VALUES (@UserName,@email,@password,@contact_number)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", account.UserName);
                    cmd.Parameters.AddWithValue("@email", account.Email);
                    string password=_mailService.SendEmail(account.Email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@contact_number", account.ContactNumber);
                    await cmd.ExecuteScalarAsync();

                }
                
            }

            return account;
        }

        public async Task<UserAccount> UpdateAccount(UserAccount updatedAccount)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE user_account SET user_name = @UserName WHERE user_account_id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", updatedAccount.UserAccountId);
                    cmd.Parameters.AddWithValue("@UserName", updatedAccount.UserName);

                    await cmd.ExecuteNonQueryAsync();                  
                }
            }
            return updatedAccount;
        }

        public async Task<string> DeleteAccount(int userId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM user_account WHERE user_account_id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return "User deleted successfully";
        }

        public async Task<string> UpdateUserStatus(int id)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE user_account SET is_active = @UserStatus WHERE user_account_id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.Parameters.AddWithValue("@UserStatus", 1);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return "User Status updated successfully";
        }

        public async Task<ResetPassword> ResetPassword(ResetPassword password)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE user_account SET password = @pass WHERE user_account_id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", password.UserAccountId);
                    cmd.Parameters.AddWithValue("@pass", password.Password);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return password;
        }
    }
}
