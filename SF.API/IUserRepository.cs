using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.Infrastructure.Users;

namespace SF.API
{
    public interface IUserRepository
    {
        IdentityUser FindUser(string userName);
        List<IdentityUser> RegisterUser(Command command);
    }
}