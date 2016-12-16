using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SF.API
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("SimplyFindUsers")
        {
            
        }

    }
}