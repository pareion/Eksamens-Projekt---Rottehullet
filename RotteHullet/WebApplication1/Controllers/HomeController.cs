using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Dette er en prøveside, der skal blive Føniks' udlånssystem.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Problemer med siden? Kontakt Arndal fra Føniks.";

            return View();
        }
    }
}