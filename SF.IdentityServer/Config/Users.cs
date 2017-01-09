using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.IdentityServer.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get() {
            return new List<InMemoryUser> {
                new InMemoryUser
                {
                    Username = "Persik",
                    Password = "secret",
                    Subject = "kljgflkj-345-sdfsdfsd-345-dgff"
                },
                new InMemoryUser
                {
                    Username = "Luter",
                    Password = "secret",
                    Subject = "asdfsd-356745-nbmvsdfsd-34sd-drrtf"
                }
            };
        }
    }
}