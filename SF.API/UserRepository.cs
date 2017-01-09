using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.Infrastructure.Users;

namespace SF.API
{
    public class UserRepository : IUserRepository
    {
        private List<IdentityUser> _users = new List<IdentityUser>
        {
            new IdentityUser {UserName = "Me", Email = "me@com"},
            new IdentityUser {UserName = "You", Email = "you@com"}
        }; 
                
        public List<IdentityUser> RegisterUser(Command command)
        {
            _users.Add(new IdentityUser {UserName = command.UserName});

            return _users;
        }

        public IdentityUser GetUsers()
        {
            IdentityUser user = _users.FirstOrDefault(u => u.UserName == userName);

            return user;
        }
    }
}