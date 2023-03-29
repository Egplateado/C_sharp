using BussinesArtesanias;
using EntityArtesanias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artesanias_Omar.Controllers
{
    public class HomeController : Controller
    {
        Bussines_artesanias Obj_buss = new Bussines_artesanias();
        public ActionResult Index()
        {
            try
            {
                List<Entity_artesanias> lista_artesanias = Obj_buss.Obtener();
                return View(lista_artesanias);

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View(new List<Entity_artesanias>());
        }

        public ActionResult Agregar_post(Entity_artesanias Artesania)
        {
            try
            {
                Obj_buss.Agregar(Artesania);
                TempData["Mensaje"] = $"La pelicula {Artesania.Nombre} se agrego correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Agregar_get");
            }
        }

        public ActionResult Agregar_get()
        {
            return View();
        }

        public ActionResult Eliminar(int Id)
        {
            try 
            {
                Entity_artesanias artesania = Obj_buss.Obtener_id(Id);
               
                Obj_buss.Eliminar(artesania);
                TempData["Mensaje"] = $"La artesania {artesania.Nombre} se elimino exitosamente";

                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar_get(int Id)
        {
            try
            {
                Entity_artesanias Artesania = Obj_buss.Obtener_id(Id);
                //Regresa la entidad a la vista
                return View(Artesania);
            }

            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Index");
            }
        }

        public ActionResult Editar_post(Entity_artesanias artesania)
        {
            try
            {
                Obj_buss.Editar(artesania);
                TempData["Mensaje"] = $"La artesania {artesania.Nombre} se edito correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message; 
                return View("Editar_get" , artesania);
            }
        }

        public ActionResult Buscar(string Buscar)
        {
            try
            {
                List<Entity_artesanias> lista = Obj_buss.Buscar(Buscar);
                return View("Index" ,lista);
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
                return View("Index" , new List<Entity_artesanias>());
        }

    }
}