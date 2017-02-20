using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Web.Routing;

namespace Consilium.Web 
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // GET /api/{resource}/{action}
            config.Routes.MapHttpRoute(
                name: "Web API RPC",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { },
                constraints: new { action = @"[A-Za-z]+", httpMethod = new HttpMethodConstraint("GET") }
                );

            // GET|PUT|DELETE /api/{resource}/{id}/{code}
            config.Routes.MapHttpRoute(
                name: "Web API Resource",
                routeTemplate: "api/{controller}/{id}/{code}",
                defaults: new { code = RouteParameter.Optional },
                constraints: new { id = @"\d+" }
                );

            // GET /api/{resource}
            config.Routes.MapHttpRoute(
                name: "Web API Get All",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
                );

            // PUT /api/{resource}
            config.Routes.MapHttpRoute(
                name: "Web API Update",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Put" },
                constraints: new { httpMethod = new HttpMethodConstraint("PUT") }
                );

            // POST /api/{resource}
            config.Routes.MapHttpRoute(
                name: "Web API Post",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
                );

            // POST /api/{resource}/{action}
            config.Routes.MapHttpRoute(
                name: "Web API RPC Post",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { },
                constraints: new { action = @"[A-Za-z]+", httpMethod = new HttpMethodConstraint("POST") }
                );


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            // config.EnableSystemDiagnosticsTracing();

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
