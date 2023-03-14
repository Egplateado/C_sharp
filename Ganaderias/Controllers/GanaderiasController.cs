using Ganaderias.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ganaderias.Controllers
{
    public class GanaderiasController : Controller
    {
        // GET: Ganaderias
        public ActionResult Index()
        {
            logica obj_get = new logica();
            DataTable dt = obj_get.get();
            return View(dt);
        }

        public ActionResult Vista_Agregar()
        {
            return View();
        }

        public ActionResult Accion_Agregar(string Nombre_del_Rancho, string Nombre_del_Dueño, int N_de_Toros, string Ubicacion_del_rancho)
        {
            logica obj_agregar = new logica();
            bool Validacion = obj_agregar.Validar_Agregar(Nombre_del_Rancho.ToLower(), Nombre_del_Dueño.ToLower());
            if (Validacion)
            {
                TempData["validar"] = $"El Rancho{Nombre_del_Rancho} del señor {Nombre_del_Dueño} ya existe";
                return View("Vista_Agregar");
            }
            else
            {
                obj_agregar.Agregar_Rancho(Nombre_del_Rancho, Nombre_del_Dueño, N_de_Toros, Ubicacion_del_rancho);
                DataTable dataTable = obj_agregar.get();
                return View("Index", dataTable);
            }
            
        }

        public ActionResult Accion_editar(string Nombre_del_Rancho, string Nombre_del_Dueño, int N_de_Toros, string Ubicacion_del_rancho , int Id)
        {
            logica obj_editar = new logica();
            bool Validacion = obj_editar.Validar_editar(Nombre_del_Rancho.ToLower(), Nombre_del_Dueño.ToLower() , Id);
            if (Validacion)
            {
                TempData["validar"] = $"El Rancho{Nombre_del_Rancho} del señor {Nombre_del_Dueño} con id  {Id} ya existe";
                return View("Vista_Agregar");
            }
            else
            {
                obj_editar.Update(Nombre_del_Rancho, Nombre_del_Dueño, N_de_Toros, Ubicacion_del_rancho , Id);
                DataTable dataTable = obj_editar.get();
                return View("Index", dataTable);
            }

        }
        public ActionResult Vista_Editar(int Id)
        {
            logica Obj_Id = new logica();
            DataRow rancho = Obj_Id.Obtener_Id(Id);
            return View(rancho);
        }

       /* public ActionResult Accion_Editar(string Nombre_del_Rancho, string Nombre_del_Dueño, int N_de_Toros, string Ubicacion_del_rancho , int Id)
        {
            logica Obj_Edit = new logica();
            Obj_Edit.Update(Nombre_del_Rancho, Nombre_del_Dueño, N_de_Toros, Ubicacion_del_rancho , Id);
            DataTable dataTable = Obj_Edit.get();

            return View("Index" ,dataTable);
        }*/
           public ActionResult Accion_Eliminar(int Id) 
        {   
            logica Obj_eliminar = new logica();
            Obj_eliminar.Eliminar(Id);
            DataTable dataTable= Obj_eliminar.get();

            return View("index" ,dataTable);
        }

        public ActionResult Buscar(string data)
        {
            logica Obj_buscar = new logica();
            DataTable tabla = Obj_buscar.Buscar(data);
            return View("Index" ,tabla);
        }

            
    }
}