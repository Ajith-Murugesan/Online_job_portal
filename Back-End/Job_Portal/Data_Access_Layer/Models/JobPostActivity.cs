namespace Data_Access_Layer.Models
{
    public class JobPostActivity
    {
        public int UserAccountId { get; set; }
        public int JobPostId { get; set; }
        public DateTime ApplyDate { get; set; }

      
    }
}
// Navigation properties
//public UserAccount UserAccount { get; set; } = new UserAccount();
//public JobPost JobPost { get; set; } = new JobPost();