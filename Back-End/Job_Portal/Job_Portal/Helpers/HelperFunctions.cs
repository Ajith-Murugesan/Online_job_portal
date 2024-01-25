using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Job_Portal.Helpers
{
    public class HelperFunctions
    {
        private readonly IConfiguration _config;
        public HelperFunctions(IConfiguration config)
        {

            _config = config;

        }
        public bool EmailVerification(string email)
        {
            bool emailExists = false;

            try
            {
                using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM user_account WHERE email = @Email", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)cmd.ExecuteScalar();
                        emailExists = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying email: {ex.Message}");
            }

            return emailExists;
        }
    }
}
