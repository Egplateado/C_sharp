using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio_animales;
using Entity_animales;
using System.Data;

namespace Animales_de_Rancho.Controllers
{
    public class HomeController : Controller
    {
        NegocioAnimales Obj_bussines = new NegocioAnimales();
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                List<EntityAnimales> lista = Obj_bussines.Obtener();
                return View(lista);

            }
            catch(Exception ex) 
            {
                TempData["Error"] = ex.Message;
                return View(new List<EntityAnimales>());

            }
            
        }

        public ActionResult Agregar_get()
        {
            return View();
        }

       public ActionResult Agregar_post(EntityAnimales Animal)
        {
            try
            {
                Obj_bussines.Agregar(Animal);
                TempData["Mensaje"] = $" El animal {Animal.Nombre} se agrego correctamente";
                return RedirectToAction("Index");
            }
            catch( Exception ex ) 
            {
                TempData["Error"]= ex.Message;
                return View("Agregar_get");
            }

            
        }

       public ActionResult Editar_get(int Id) 
        {
            EntityAnimales Animal = Obj_bussines.Obtener_id(Id);
            
            return View(Animal); 
        }
        public ActionResult Editar_post(EntityAnimales Animal)
        {
            try
            {
                Obj_bussines.Editar(Animal);
                TempData["Mensaje"] = $"El Animal {Animal.Nombre} Se edito correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception Ex)
            {
                TempData["Error"] = Ex.Message;
                throw;
            }
        }
        public ActionResult Eliminar(int Id)
        {
            try
            {
                EntityAnimales Animal = Obj_bussines.Obtener_id(Id);
                Obj_bussines.Eliminar(Animal.Id);
                TempData["Mensaje"] = $"El {Animal.Nombre} feu eliminado con exito";
                return RedirectToAction("Index");
            }

            catch (Exception ex) 
            {
                TempData["Error"]= ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Buscar(string Palabra)
        {
            try
            {
                List<EntityAnimales>  buscar = Obj_bussines.Buscar(Palabra);
                return View("Index", buscar);

            }
            catch(Exception ex)  
            {
                TempData["Error"]= ex.Message;
                return RedirectToAction("Index");
            }
            

        }
    }
}