namespace Data_Access_Layer.Models
{
    public class JobPost
    {
        public int JobPostId { get; set; }
        public int UserAccountId { get; set; }
        public int CompanyId { get; set; }
        public int JobTypeId { get; set; }
        public string JobDescription { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int LocationId { get; set; }
        public string IsActive { get; set; } = string.Empty;

        // Navigation properties
        public UserAccount UserAccount { get; set; } = new UserAccount();
        public Company Company { get; set; } = new Company();
        public JobType JobType { get; set; } = new JobType();
        public JobLocation JobLocation { get; set; } = new JobLocation();
    }
}
