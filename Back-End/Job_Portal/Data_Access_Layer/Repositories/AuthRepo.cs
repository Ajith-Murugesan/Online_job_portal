using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repositories
{
    public class AuthRepo : IAuth
    {
        private readonly IConfiguration _configuration;
       

        public AuthRepo(IConfiguration configuration)
        {
            _configuration = configuration;
 
        }

       // public async Task<string> Login(Login _userData)
        public async Task<LoginResponse> Login(Login _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetAdmin(_userData.Email, _userData.Password);
                if (user != null && user.IsActive)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                        new Claim("Email", user.Email),
                        new Claim("Password", user.Password),
                        new Claim(ClaimTypes.Role, user.UserTypeId== 1 ? "Applicant" : "Employeer"),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                    var res = new LoginResponse{
                        Token= new JwtSecurityTokenHandler().WriteToken(token),
                        UserTypename=user.UserTypeId.ToString(),
                        UserAccountId=user.UserAccountId
                    };

                    return res;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private async Task<UserData> GetAdmin(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (var command = new SqlCommand("SELECT user_account_id,Email, Password,user_type_id,is_active FROM user_account WHERE Email = @Email AND Password = @Password", con))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new UserData
                            {
                                UserAccountId = Convert.ToInt32(reader["user_account_id"]),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                UserTypeId = Convert.ToInt32(reader["user_type_id"]),
                                IsActive= Convert.ToBoolean(reader["is_active"].ToString())
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
