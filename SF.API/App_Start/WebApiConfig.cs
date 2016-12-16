using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
        }
    }
}
