using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Medicamentos.Models.Entity
{
    public class Medicamento
    {
        public int Id 
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }

        public string Tipo 
        { 
            get;
            set;
        }

        public string Fecha 
        { 
            get;
            set; 
        }

        public string Precio 
        {
            get;
            set;
        }
    }
}