using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class RegisterUser
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public long ContactNumber { get; set; }
    }
}
