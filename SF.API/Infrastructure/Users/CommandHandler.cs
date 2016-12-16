using System;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SF.API.Infrastructure.Users
{
    public class CommandHandler : RequestHandler<Command>
    {
        private IUserRepository _repo;

        public CommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        protected override void HandleCore(Command message)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = message.UserName
            };

            _repo.RegisterUser(message);
        }
    }
}