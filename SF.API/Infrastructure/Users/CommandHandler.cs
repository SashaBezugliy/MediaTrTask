using System;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SF.API.Infrastructure.Users
{
    public class CommandHandler : RequestHandler<Command>
    {
        private UserManager<IdentityUser> _userManager;

        public CommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override void HandleCore(Command message)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = message.UserName
            };

            _userManager.Create(user, message.Password);
        }
    }
}