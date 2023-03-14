using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercico_1.Controllers
{
    public class Practica_1Controller : Controller
    {
        // GET: Practica_1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vista_1()
        {
            return View("VIEW_2");
        }
        public ActionResult Vista_2 ()
        {
            return View();
        }
    }
}