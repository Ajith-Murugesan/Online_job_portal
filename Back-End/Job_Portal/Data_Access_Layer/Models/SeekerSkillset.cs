namespace Data_Access_Layer.Models
{
    public class SeekerSkillset
    {
        public int UserAccountId { get; set; }
        public int SkillsetId { get; set; }
        public int SkillLevel { get; set; }

        // Navigation properties
        public UserAccount UserAccount { get; set; } = new UserAccount();
        public Skillset Skillset { get; set; } = new Skillset();
    }
}
