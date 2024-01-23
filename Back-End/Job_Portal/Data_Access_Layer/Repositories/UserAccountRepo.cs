using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, user_name, email, contact_number, is_active,user_type_id,password FROM user_account WHERE user_account_id = @UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            userAccount.UserAccountId = reader.GetInt32(0);
                            userAccount.UserName = reader.GetString(1);
                            userAccount.Email = reader.GetString(2);
                            userAccount.ContactNumber = reader.IsDBNull(3) ? 00000000000 : reader.GetInt64(3);
                            userAccount.IsActive = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                            userAccount.UserTypeId = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            userAccount.Password = reader.GetString(6);
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
                            UserTypeId = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
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

                string insertQuery = "INSERT INTO user_account (user_name,email,password,contact_number,user_type_id) VALUES (@UserName,@email,@password,@contact_number,@typeid)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", account.UserName);
                    cmd.Parameters.AddWithValue("@email", account.Email);
                    string password = _mailService.SendEmail(account.Email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@contact_number", account.ContactNumber);
                    cmd.Parameters.AddWithValue("@typeid", account.UserTypeId);
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

        public async Task<UpdateUserStatusResponse> DeleteAccount(DeleteInfo deleteInfo)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM user_account WHERE user_account_id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", deleteInfo.UserAccountId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            _mailService.SendFeedbackEmail(deleteInfo.Email,deleteInfo.Feedback);
            var response = new UpdateUserStatusResponse
            {
                Message = "User deleted successfully"
            };

            return response;
        }

        public async Task<UpdateUserStatusResponse> UpdateUserStatus(UpdateUserStatus status)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE user_account SET is_active = @UserStatus WHERE user_account_id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", status.UserAccountId);
                    cmd.Parameters.AddWithValue("@UserStatus", 1);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            _mailService.SendverificationEmail(status.Email);
            var response = new UpdateUserStatusResponse
            {
                Message = "User Status updated successfully"
            };

            return response;
        }

        public async Task<ResetPassword> ResetPassword(ResetPassword password)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE user_account SET password = @newpass, is_fstlogin = 1 WHERE email = @email AND password = @oldpass;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@email", password.Email);
                    cmd.Parameters.AddWithValue("@oldpass", password.oldPassword);
                    cmd.Parameters.AddWithValue("@newpass", password.newPassword);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return password;
        }


        public async Task<UserAccount> GetUser(Login usr)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, user_name, email, contact_number, is_active,user_type_id,password FROM user_account WHERE email = @email and password=@pass", con))
                {
                    cmd.Parameters.AddWithValue("@email", usr.Email);
                    cmd.Parameters.AddWithValue("@pass", usr.Password);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            userAccount.UserAccountId = reader.GetInt32(0);
                            userAccount.UserName = reader.GetString(1);
                            userAccount.Email = reader.GetString(2);
                            userAccount.ContactNumber = reader.IsDBNull(3) ? 00000000000 : reader.GetInt64(3);
                            userAccount.IsActive = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                            userAccount.UserTypeId = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            userAccount.Password = reader.GetString(6);

                        }
                    }
                }

                return userAccount;
            }
        }

        public async Task<ICollection<JobApplication>> GetJobApplicationById(int id)
        {
            List<JobApplication> jobapplications = new List<JobApplication>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("GetJobApplicationByEmployeerid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_account_id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            jobapplications.Add(new JobApplication
                            {
                                UserAccountId = reader.GetInt32(0),
                                JobPostId = reader.GetInt32(1),
                                ApplyDate= reader.GetDateTime(2),
                                UserName = reader.GetString(3),
                                CompanyName = reader.GetString(4),
                                JobTypeName = reader.GetString(5),
                                JobTitle = reader.GetString(6),
                                JobDescription = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                CreatedDate = reader.GetDateTime(8),
                                Address = reader.GetString(9),
                                City = reader.GetString(10),
                                State = reader.GetString(11),
                                Pincode = reader.GetInt32(12),
                                IsActive = reader.GetString(13)
                            });
                        }
                    }
                }
            }

            return jobapplications;
        }
    }
}
