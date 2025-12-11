using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net8API.Models;

namespace net8API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}