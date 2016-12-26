using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Serilog;
using SF.API.App_Start;
using SF.API.DependencyResolution;
using SF.API.ExceptionHandling;

namespace SF.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "get-product-lists",
                routeTemplate: "productlists/{userId}",
                defaults: new { controller = "Product", action = "GetProductLists"}
            );

            var container = StructuremapMvc.StructureMapDependencyScope.Container;
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
            config.Services.Replace(typeof(IHttpControllerActivator), config.DependencyResolver);
            config.Filters.Add(new CustomExceptionFilterAttribute());

        }
    }
}
