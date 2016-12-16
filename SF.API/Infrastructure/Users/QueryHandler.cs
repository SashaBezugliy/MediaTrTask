using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SF.API.Infrastructure.Users
{
    public class QueryHandler : IRequestHandler<Query, Command>
    {
        private IUserRepository _repo;

        public QueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public Command Handle(Query message)
        {
            IdentityUser user = _repo.FindUser(message.UserName);
            if (user == null)
                return null;

            return new Command
            {
                ConfirmPassword = user.PasswordHash,
                Password = user.PasswordHash,
                UserName = user.UserName
            };
        }
    }
}