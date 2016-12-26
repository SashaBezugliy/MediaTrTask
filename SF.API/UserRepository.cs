using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.ExceptionHandling;
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

            Enum.Parse(typeof(ErrorMessages), "InRepository");

            return _users;
        }

        public IdentityUser FindUser(string userName)
        {
            IdentityUser user = _users.FirstOrDefault(u => u.UserName == userName);

            return user;
        }
    }
}