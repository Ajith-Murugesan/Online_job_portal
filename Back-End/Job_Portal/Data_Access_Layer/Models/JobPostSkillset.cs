namespace Data_Access_Layer.Models
{
    public class JobPostSkillset
    {
        public int SkillsetId { get; set; }
        public int JobPostId { get; set; }
        public int SkillLevel { get; set; }

        // Navigation properties
        public Skillset Skillset { get; set; } = new Skillset();
        public JobPost JobPost { get; set; } = new JobPost();
    }
}
