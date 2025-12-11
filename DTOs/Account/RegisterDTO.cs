using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net8API.DTOs.Account
{
    public class RegisterDTO
    {
        [Required]
        public string? Username {get;set;}

        [Required]
        public string? Password {get;set;}

        [Required]
        [EmailAddress]
        public string? Email {get;set;}
    
    }
}