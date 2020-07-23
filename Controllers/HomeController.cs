using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;             
using System.Web.Mvc;

namespace SC_MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Interview()
        {
            ViewBag.Message = "An interview with Susan.";

            return View();
        }
        public ActionResult Biography()
        {
            ViewBag.Message = "The author's biography.";

            return View();
        }

    }
}
