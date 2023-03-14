using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webString.Models;

namespace webString.Controllers
{
    public class cadenaController : Controller
    {
        // GET: cadena
        public ActionResult Practica()
        {
            return View();
        }

        public ActionResult Data_contar(string Data)
        {
           
            logica obj_contar = new logica();
            string result = obj_contar.Contar(Data);

            TempData["Numero"] = result;
            return View("Practica");
        }

        public ActionResult Data_mayuscula(string Data_mayus) 
        {
            string result;
            string mostrar;
            logica obj_mayus = new logica();
            result = obj_mayus.Mayuscula(Data_mayus);
            mostrar = result;
            TempData["Mostrar_mayus"] = mostrar;
            return View("Practica");
        }
        public ActionResult Data_minuscula(string Data_minus)
        {
            string result;
            string mostrar;
            logica obj_minus = new logica();
            result = obj_minus.Minuscula(Data_minus);
            mostrar = result;
            TempData["Mostrar_minus"] = mostrar;
            return View("Practica");
        }
        
        public ActionResult Concatenar (string caja_1 , string caja_2 , string caja_3)
        {
            string result;
            logica obj_concatenar = new logica();
            result = obj_concatenar.Concatenar(caja_1 , caja_2, caja_3);
            TempData["mostrar_concatenar"] = result;
            return View("Practica");
        }

        public ActionResult Validar_sentence(string caja_1 , string caja_2)
        {
            string confirmacion;
            logica obj_valida = new logica();
            bool result = obj_valida.Validacion(caja_1 ,caja_2);
            if(result) 
            {
                confirmacion = $"{caja_2} esta contenida en '{caja_1}'";
                TempData["mostrar_validacion"] = confirmacion;
            }
            else
            {
                confirmacion = $"{caja_2} NO esta contenida en '{caja_1}'";
                TempData["mostrar_validacion"] = confirmacion;
            }
            return View("Practica");
        }

        public ActionResult Data_clear(string cadena)
        {
            string result;
            logica obj_clear = new logica();
            result = obj_clear.Data_clear(cadena);
            TempData["limpio"] = result;
            return View("Practica");
        }

        public ActionResult Data_coma(string cadena_coma) 
        {
            string result;
            logica obj_coma = new logica();
            result = obj_coma.Data_coma(cadena_coma);
            TempData["coma"] = result;

            return View("Practica");
        }

        public ActionResult Data_espacios(string espacios) 
        {
            logica obj_espacios = new logica();
            string result = obj_espacios.Espacio(espacios);
            TempData["espacio"] = result; ;

            return View("Practica");
        }

        public ActionResult Validar_word(string data)
        {
            logica obj_word = new logica();
            bool result = obj_word.Validar_word(data);
            if(result) 
            {
                string view = $"{data} SI inicia con 'Ti'";

            TempData["ti"] = view; 
            }
            else
            {
                string view = $"{data} NO inicia con 'Ti'";

                TempData["ti"] = view;
            }
            return View("Practica");
        }

        public ActionResult Pad(string data_pad)
        {
            logica obj_pad = new logica();
            string result = obj_pad.Pad(data_pad);
            TempData["PAD"] = result;

            return View("Practica");
        }

        public ActionResult Data_mayus(string data_mayus)
        {
            logica obj_data_mayus = new logica();
            string result = obj_data_mayus.Data_mayus(data_mayus);
            TempData["id"] = result;
            return View("Practica");
        }

        public ActionResult Data_alreves(string data_alreves)
        {
            logica obj_data_alreves = new logica();
            string result = obj_data_alreves.Data_alreves(data_alreves);
            TempData["alreves"] = result;
            return View("Practica");
        }
        public ActionResult Data_vocales(string vocales)
        {
            string cadena;
            logica obj_data_vocales = new logica();
            int result = 0;
            result = obj_data_vocales.Data_vocales(vocales);
            cadena = $"En {vocales} hay {result} vocales";
            TempData["vocales"] = cadena;

            return View("Practica");
        }
    }
}