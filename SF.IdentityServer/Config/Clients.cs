using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace SF.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
                         {
                new Client
                {
                     ClientId = "tripgalleryclientcredentials",
                     ClientName = "Trip Gallery (Client Credentials)",
                     Flow = Flows.ClientCredentials,
                     AllowAccessToAllScopes = true,

                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(Constants.SF_ClientSecret.Sha256())
                    }
                }
                ,
                new Client
                {
                     ClientId = "tripgalleryauthcode",
                     ClientName = "Trip Gallery (Authorization Code)",
                     Flow = Flows.AuthorizationCode,
                     AllowAccessToAllScopes = true,

                    // redirect = URI of the MVC application callback
                    RedirectUris = new List<string>
                    {
                        Constants.SF_MVC_STSCallback
                    },           

                    // client secret
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(Constants.SF_ClientSecret.Sha256())
                    }
                }
                ,
                new Client
                {
                     ClientId = "tripgalleryimplicit",
                     ClientName = "Angular Client (Implicit)",
                     Flow = Flows.Implicit,
                     AllowAccessToAllScopes = true,

                    // redirect = URI of the Angular application callback page
                    RedirectUris = new List<string>
                    {
                        Constants.SF_Angular + "callback.html"
                    }
                }
                ,
                new Client
                {
                     ClientId = "tripgalleryropc",
                     ClientName = "Trip Gallery (Resource Owner Password Credentials)",
                     Flow = Flows.ResourceOwner,
                     AllowAccessToAllScopes = true,

                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(Constants.SF_ClientSecret.Sha256())
                    }
                }

             };
        }
    }
}