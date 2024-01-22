using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.ViewModels
{
    public class JobApplication
    {
        public int UserAccountId { get; set; }
        public int JobPostId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string JobTypeName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; } = 0;
        public string IsActive { get; set; } = string.Empty;
    }
}
