namespace Data_Access_Layer.DTOs
{
    public class DeleteInfo
    {
        public int UserAccountId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Feedback { get; set; } = string.Empty;
    }
}
