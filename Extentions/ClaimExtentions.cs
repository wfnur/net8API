using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace net8API.Extentions
{
    public static class ClaimExtentions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals(ClaimTypes.GivenName))?.Value;
        }
        
    }
}