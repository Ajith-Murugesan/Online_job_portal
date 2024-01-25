namespace Data_Access_Layer.Models
{
    public class ExperienceDetails
    {
        public int UserAccountId { get; set; }
        public string IsCurrentJob { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

       
    }
}
