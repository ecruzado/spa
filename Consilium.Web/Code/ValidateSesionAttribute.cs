using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consilium.Web.Code
{
    public class ValidateSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = filterContext.HttpContext.Session[Constantes.Usuario];

            if (usuario == null)
            {
                var routeValues = new System.Web.Routing.RouteValueDictionary();
                routeValues["controller"] = "Account";
                routeValues["action"] = "LogOn";
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
        }
    }
}