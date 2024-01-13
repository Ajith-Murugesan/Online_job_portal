namespace Data_Access_Layer.Models
{
    public class JobLocation
    {
        public int LocationId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; } = 0;
    }
}
