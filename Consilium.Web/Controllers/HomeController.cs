﻿using Consilium.Entity;
using Consilium.Web.Code;
using Consilium.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consilium.Web.Controllers
{
    [Authorize]
    [ValidateSesion]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var usuario  = (Usuario)System.Web.HttpContext.Current.Session[Constantes.Usuario];
            return View();
        }
    }
}
