using BussinesPeliculas;
using EntityPelicula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas_tres_capas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BPelicula Obj_peli = new BPelicula();
        public ActionResult Index()
        {
            try
            {
                List<EPelicula> Lista_peli = Obj_peli.Obtener();
                return View(Lista_peli);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View(new List<EPelicula>());
        }
        public ActionResult Agregar_post(EPelicula pelicula)
        {
            try
            {
                Obj_peli.Agregar(pelicula);
                TempData["Mensaje"] = $"La pelicula {pelicula.Nombre} se agrego exitosamente";
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

        public ActionResult Editar_get(int Id)
        {
            try
            {
                EPelicula pelicula = Obj_peli.Obtener_id(Id);

                return View(pelicula);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("Index");

            }
        }

        public ActionResult Editar_post(EPelicula pelicula)
        {
            try
            {
                Obj_peli.Editar(pelicula);
                TempData["Mensaje"] = $"La pelicula {pelicula.Nombre} se edito exitosamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Editar_get" , pelicula);
            }
        }

        public ActionResult Eliminar(int Id)
        {
            try
            {
                EPelicula pelicula = Obj_peli.Obtener_id(Id);
               Obj_peli.Eliminar(pelicula);
                TempData["Mensaje"] = $"La pelicula  {pelicula.Nombre} se elimino exitosamente";

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");

            }
        }

        public ActionResult Buscar(string Palabra)
        {
            try
            {
                List<EPelicula> Lista_peli = Obj_peli.Buscar(Palabra);
                return View("Index" ,Lista_peli);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View("Index" , new List<EPelicula>());
        }
    }
        
}