using IdentityServer3.Core.Configuration;
using Owin;
using SF.IdentityServer.Config;
using SF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Services.Default;

namespace SF.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idservApp =>
            {
                var corsPolicyService = new DefaultCorsPolicyService()
                {
                    AllowAll = true
                };

                var idServerServiceFactory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryUsers(Users.Get())
                .UseInMemoryScopes(Scopes.Get());

                idServerServiceFactory.CorsPolicyService = new
                    Registration<IdentityServer3.Core.Services.ICorsPolicyService>(corsPolicyService);

                var options = new IdentityServerOptions
                {
                    Factory = idServerServiceFactory,
                    SiteName = "SF Security Token Service",
                    IssuerUri = Constants.SF_IssuerUri,
                    PublicOrigin = Constants.SF_STSOrigin,
                    SigningCertificate = LoadCertificate()
                };

                idservApp.UseIdentityServer(options);
            });
        }
        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}