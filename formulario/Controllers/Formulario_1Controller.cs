using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace formulario.Controllers
{
    public class Formulario_1Controller : Controller
    {
        // GET: Formulario_1
        public ActionResult Vista()
        {
            return View();
        }
        public ActionResult Concatenar(string nombre , string apellidos , int edad) 
        {
            string result = $"Mi nombre es {nombre} {apellidos} y mi edad es {edad} años";
            TempData["mensaje"] = result;
            return View("Vista");
        }
    }
}