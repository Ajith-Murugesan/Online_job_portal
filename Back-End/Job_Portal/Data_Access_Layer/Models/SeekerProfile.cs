namespace Data_Access_Layer.Models
{
    public class SeekerProfile
    {
        public int UserAccountId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long CurrentSalary { get; set; }

       
    }
}
// Navigation property
//public UserAccount UserAccount { get; set; } = new UserAccount();