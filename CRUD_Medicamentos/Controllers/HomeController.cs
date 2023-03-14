using CRUD_Medicamentos.Models;
using CRUD_Medicamentos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Medicamentos.Controllers
{
    public class HomeController : Controller
    {
        data obj_data = new data();

        public ActionResult Index()
        {
            try
            {
                DataTable tabla = obj_data.Obtener_tabla();
                return View(tabla);
            }
            catch(Exception ex) 
            {
                TempData["Error"] = ex.Message;

                return View(new DataTable());// Manda tabla vacía a la vista
            }

            
        }

        public ActionResult Agregar_get()
        {
            return View();
        }

        public ActionResult Agregar_post(Medicamento med) 
        {
            try
            {
                obj_data.Agregar_medicamento(med);
                TempData["Mensaje"] = "El medicamento se agrego correctamente";
                return RedirectToAction("Index");
            }

            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Agregar_get");
            }
        }

        public ActionResult Eliminar(int Id)
        {
            try
            {
                obj_data.Eliminar(Id);
                DataTable Tabla_medicamentos = new DataTable();
                Tabla_medicamentos = obj_data.Obtener_tabla();
                return RedirectToAction("Index", Tabla_medicamentos);
                
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(Medicamento med)
        {
            bool validar;
            try
            {
            validar = obj_data.Editar_validar(med);
                if (validar)
                {
                    TempData["mensaje"] = $"El medicamento {med.Nombre} ya existe";

                    return RedirectToAction("Index");
                }

                else
                {
                    obj_data.Editar(med);
                    DataTable Tabla = new DataTable();
                    Tabla = obj_data.Obtener_tabla();

                    return RedirectToAction("Index", Tabla);
                }
            }
            catch(Exception ex) 
            {
                TempData["Error"] = ex.Message; 
                return RedirectToAction("Index");
            }
        }

        public ActionResult Vista_editar( int Id)
        {
            DataRow fila = obj_data.Fila(Id);
            return View(fila);
        }

    }
}