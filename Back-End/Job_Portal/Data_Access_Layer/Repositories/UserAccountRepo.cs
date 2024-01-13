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

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, user_name FROM user_account", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new UserAccount
                        {
                            UserAccountId = reader.GetInt32(0),
                            UserName = reader.GetString(1)
                        });
                    }
                }
            }

            return users;
        }

        public async Task<UserAccount> CreateAccount(UserAccount account)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO user_account (user_name,email,password) VALUES (@UserName,@email,@password)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", account.UserName);
                    cmd.Parameters.AddWithValue("@email", account.Email);
                    string password=_mailService.SendEmail(account.Email);
                    cmd.Parameters.AddWithValue("@password", password);
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


    }
}
