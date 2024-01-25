namespace Data_Access_Layer.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime UserDOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public long ContactNumber { get; set; }
        public string UserImage { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }

       
    }
}