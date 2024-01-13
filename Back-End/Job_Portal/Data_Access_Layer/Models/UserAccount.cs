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
        public string IsActive { get; set; } = string.Empty;
        public long ContactNumber { get; set; }
        public string UserImage { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
     /*   public UserType UserType { get; set; } = new UserType();
        public SeekerProfile SeekerProfile { get; set; } = new SeekerProfile();
        public EducationalDetails EducationalDetails { get; set; } = new EducationalDetails();
        public ExperienceDetails ExperienceDetails { get; set; } = new ExperienceDetails();*/
    }
}
