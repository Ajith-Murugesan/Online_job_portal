using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string UserTypename { get; set; } = string.Empty;
    }
}
