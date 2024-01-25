namespace Data_Access_Layer.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public int StreamId { get; set; }
        public string CompanyDescription { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string CompanyImage { get; set; } = string.Empty;
        public int UserAccountId { get; set; }


    }
}
