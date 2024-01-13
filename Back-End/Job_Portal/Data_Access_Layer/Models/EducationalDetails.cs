namespace Data_Access_Layer.Models
{
    public class EducationalDetails
    {
        public int UserAccountId { get; set; }
        public string DegreeName { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string InstituteName { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Percentage { get; set; }
        public int CGPA { get; set; }

        // Navigation property
        public UserAccount UserAccount { get; set; } = new UserAccount();
    }
}
