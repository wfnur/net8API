using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net8API.DTOs.Account
{
    public class NewUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    
    }
}