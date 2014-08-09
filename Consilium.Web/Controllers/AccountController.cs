using Consilium.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Consilium.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            logout();
            if (ModelState.IsValid)
            {
                if (true)
                {
                    var usuario = model.UserName;
                    Session.Add("USUARIO", usuario);
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El nombre de Usuario o la Contraseña es incorrecto");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void logout()
        {

            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpCookie cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

        }

        public ActionResult VerificarUsuario() 
        {
            var resultado = new JsonResult();
            var usuario = String.Empty;
            var sesionActiva = false;
            if (Session["USUARIO"] != null) {
                usuario = Session["USUARIO"].ToString();
                sesionActiva = true;
            }
            resultado.Data = new {sesionActiva = sesionActiva, usuario="edgar"};
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return resultado;
        }
    }
}
