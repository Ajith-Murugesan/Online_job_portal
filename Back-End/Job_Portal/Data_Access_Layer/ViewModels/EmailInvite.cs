using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.ViewModels
{
    public class EmailInvite
    {
        public int UserAccountId { get; set; }
        public int JobPostId { get; set; }
        public string JobPosition { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public string InterviewDate { get; set; } = string.Empty;
        public string InterviewTime { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
    }
}
