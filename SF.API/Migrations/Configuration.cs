using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.Infrastructure.DataAccess;

namespace SF.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SF.API.Infrastructure.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
 
            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext()));
 
            var user = new IdentityUser()
            {
                UserName = "SuperPowerUser",
                Email = "taiseer.joudeh@mymail.com",
                EmailConfirmed = true
            };
 
            manager.Create(user, "MySuperP@ssword!");
        }
    }
}
