using Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pacientes.Controllers
{
    public class PacientesController : Controller
    {
        logica obj = new logica();//objeto global para que todos los metodos lo puedad ocupar
        // GET: Pacientes
        public ActionResult Index()
        {
            try
            {
                DataTable dt = obj.Obtener_tabla();
                return View(dt);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                DataTable dt2 = new DataTable();
                return View(dt2);
            }
        }

        public ActionResult Agregar_paciente() 
        {
            return View();
        }

        public ActionResult Post_paciente(string Nombre_del_paciente, string Apellidos, int Edad)
        {
            try
            {
                bool validar = obj.Validar_paciente(Nombre_del_paciente, Apellidos, Edad);
                if (validar)
                {
                    TempData["Mensaje"] = $"El usuario {Nombre_del_paciente} ya existe";
                    return View("Agregar_paciente");
                }
                else
                {
                    obj.Agregar_pacientes(Nombre_del_paciente, Apellidos, Edad);
                    TempData["Mensaje"] = $"El usuario {Nombre_del_paciente} se agrego exitosamente";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex ) 
            {
                TempData["Error"] = ex.Message;
                return View("Agregar_paciente");
            }
        }

        public ActionResult Delete_paciente(int Id) 
        {
            try 
            {
                obj.Dele_paciente(Id);
                DataTable Tabla_pacientes = new DataTable();
                Tabla_pacientes = obj.Obtener_tabla();

                return View("Index", Tabla_pacientes);
            }
            catch (Exception ex) 
            {
                TempData["Error_eliminar"] = ex.Message;
                return View("Index");
            }
        }

        public ActionResult Update_paciente (int Id )
        {
            try
            {
                obj.Update_paciente(Id);
            }
            return View();
        }
    }
}