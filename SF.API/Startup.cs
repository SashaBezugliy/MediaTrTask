using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin;
using Owin;
using SF.API;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(Startup))]
namespace SF.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = Constants.SF_STS,
                    RequiredScopes = new[] { "productmanagment" }
                });

            WebApiConfig.Register(config);
            app.UseWebApi(config);

        }

    }
}