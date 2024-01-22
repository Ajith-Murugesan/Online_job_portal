using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class UpdateUserStatus
    {
        public int UserAccountId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
