using crud_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            logica obj = new logica();
            DataTable dt = obj.Get();

            return View(dt);
        }

        public ActionResult Add_view()
        {
            return View();
        }

        public ActionResult Accion_agregar(string Nombre , string A_paterno , string A_materno , int Edad)
        {
            logica obj = new logica();
            obj.Agregar(Nombre , A_paterno, A_materno , Edad);
            DataTable dt = obj.Get();
            return View("Index" , dt);
        }

        public ActionResult Vista_editar(int id) 
        {
            logica obj = new logica();
            DataRow persona = obj.Obtener_id(id);


            return View(persona);
        }
        public ActionResult Accion_editar(string Nombre , string A_paterno , string A_materno , int edad , int id)
        {
            logica obj = new logica();
            obj.Update( Nombre,  A_paterno, A_materno,  edad,  id);
            DataTable td = obj.Get();

            return View("Index" , td);
        }
        public ActionResult Accion_eliminar( int id)
        {
            logica obj = new logica();
            obj.Eliminar(id);
            DataTable td = obj.Get();

            return View("Index", td);
        }
    }
}