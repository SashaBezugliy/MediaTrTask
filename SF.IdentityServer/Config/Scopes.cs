using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace SF.IdentityServer.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>()
            {
                new Scope
                {
                    Name = "productmanagment",
                    DisplayName = "Products Managment",
                    Description = "Allows app manage products",
                    Type = ScopeType.Resource
                }
            };
        }
    }
}