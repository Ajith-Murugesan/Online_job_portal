﻿using Data_Access_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IAuth
    {
       // Task<string> Login(Login login);
        Task<LoginResponse> Login(Login login);
    }
}
