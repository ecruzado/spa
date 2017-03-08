using Consilium.Entity;
using Consilium.Logica;
using Consilium.Web.Code;
using Consilium.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace Consilium.Web.Controllers
{
    [Authorize]    
    public class AccountController : Controller
    {
        //
        // GET: /Account/LogOn
        [AllowAnonymous]   
        public ActionResult LogOn(string acceso)
        {
            if (acceso == null)
            {
                return Redirect("http://consilium-educacion.jimdo.com");
            }
            return View();
        }

        //
        // POST: /Account/LogOn

        [AllowAnonymous]   
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            //logout();
            if (ModelState.IsValid)
            {
                var usuario = UsuarioLogica.Instancia.GetById(295);
                //var usuario = UsuarioLogica.Instancia.GetByUsuarioAndPassword(model.UserName, model.Password);
                if (usuario != null)
                {
                    System.Web.HttpContext.Current.Session.Add(Constantes.Usuario, usuario);
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

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

        [HttpGet]
        public ActionResult VerificarUsuario() 
        {
            var resultado = new JsonResult();
            Usuario usuario = null;
            var sesionActiva = false;
            if (System.Web.HttpContext.Current.Session[Constantes.Usuario] != null)
            {
                usuario = (Usuario)System.Web.HttpContext.Current.Session[Constantes.Usuario];
                sesionActiva = true;
            }
            resultado.Data = new {sesionActiva = sesionActiva, usuario="edgar"};
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return resultado;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public JsonResult ObtenerUsuario()
        {
            var usuario = (Usuario)System.Web.HttpContext.Current.Session[Constantes.Usuario];

            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
    }
}
