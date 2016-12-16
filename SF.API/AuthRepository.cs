using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.Infrastructure.Users;

namespace SF.API
{
    public class AuthRepository : IRequestHandler<Query, Command>
    {
        private AuthContext _ctx;
        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }
        

        public IdentityResult RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = _userManager.Create(user, userModel.Password);

            return result;
        }

        public IdentityUser FindUser(string userName, string password)
        {
            IdentityUser user = _userManager.Find(userName, password);

            return user;
        }

        public Command Handle(Query message)
        {
            throw new NotImplementedException();
        }
    }
}