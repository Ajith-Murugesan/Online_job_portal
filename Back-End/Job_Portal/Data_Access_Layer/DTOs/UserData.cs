﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class UserData
    {
        public int UserAccountId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; } = false;
        public bool isFirstLogin { get; set; }

    }
}
