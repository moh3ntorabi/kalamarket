using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Utilities
{
    public static class ClaimUtility
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}
