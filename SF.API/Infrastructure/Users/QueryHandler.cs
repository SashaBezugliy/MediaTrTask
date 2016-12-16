using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SF.API.Infrastructure.Users
{
    public class QueryHandler : IRequestHandler<Query, Command>
    {
        private UserManager<IdentityUser> _userManager;

        public QueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public Command Handle(Query message)
        {
            IdentityUser user = _userManager.Find(message.UserName, message.Password);

            return new Command
            {
                ConfirmPassword = user.PasswordHash,
                Password = user.PasswordHash,
                UserName = user.UserName
            };
        }
    }
}