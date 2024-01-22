using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class ResetPassword
    {
        public string Email { get; set; } = string.Empty;
        public string oldPassword { get; set; } = string.Empty;
        public string newPassword { get; set; } = string.Empty;

    }
}
