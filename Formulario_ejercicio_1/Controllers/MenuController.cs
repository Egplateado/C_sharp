using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Formulario_ejercicio_1.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult menu_view()
        {
            return View();
        }

        public ActionResult data_name()
        {
            return View();
        }

        public ActionResult Aceptar(string Nombre , string Paterno ,string Materno)
        {
            string result = $"Mi nombre es {Nombre} {Paterno} {Materno}";
            TempData["Aceptar"] = result;
            return View("data_name");
        }
        public ActionResult data_address_view()
        {
            return View();
        }

        public ActionResult data_address(string street , string colonia , string delegacion)
        {
            string result = $"Calle {street} , col.{colonia}, del.{delegacion}";
            TempData["address"] = result;
            return View("direccion");
        }

    }
}