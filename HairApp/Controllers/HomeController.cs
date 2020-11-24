using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hair_Quiz()
        {
            return View();
        }

        public ActionResult Washing_Schedule()
        {
            return View();
        }

        public ActionResult CheckIngredients()
        {
            return View();
        }
    }
}