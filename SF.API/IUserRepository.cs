using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.Infrastructure.Users;

namespace SF.API
{
    public interface IUserRepository
    {
        IdentityUser GetUsers();
        List<IdentityUser> RegisterUser(Command command);
    }
}