using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data_animales;
using Entity_animales;

namespace Negocio_animales
{
    public class NegocioAnimales
    {
        DataAnimales Data = new DataAnimales();

        public List<EntityAnimales> Obtener()
        {
            //Obtenemos la tabla de la db
            DataTable Tabla = Data.Obtener();
            //Creamos una lista Vacía
            List<EntityAnimales> lista = new List<EntityAnimales>();

            foreach (DataRow dr in Tabla.Rows) 
            {
                EntityAnimales Animales = new EntityAnimales();
                //Convertimos los datos obtenidos de la db 
                Animales.Nombre = Convert.ToString(dr["Nombre"]);
                Animales.Tipo = Convert.ToString(dr["Tipo"]);
                Animales.Color = Convert.ToString(dr["Color"]);
                Animales.Edad = Convert.ToInt32(dr["Edad"]);
                Animales.Id = Convert.ToInt32(dr["Id"]);

                lista.Add(Animales);
            }

            return lista;
        }

        public EntityAnimales Obtener_id(int Id)
        {
            DataRow Animal_id = Data.Obtener_Id(Id);

            EntityAnimales Animal = new EntityAnimales();

            Animal.Nombre = Convert.ToString(Animal_id["Nombre"]);
            Animal.Tipo = Convert.ToString(Animal_id["Tipo"]);
            Animal.Color = Convert.ToString(Animal_id["Color"]);
            Animal.Edad = Convert.ToInt32(Animal_id["Edad"]);
            Animal.Id = Convert.ToInt32(Animal_id["Id"]);

            return Animal;
        }

        public void Agregar(EntityAnimales Animal)
        {
            int Fila_Agregar;
            Fila_Agregar = Data.Agregar(Animal.Nombre, Animal.Tipo , Animal.Color , Animal.Edad);
            bool result = Convert.ToBoolean(Fila_Agregar);

            if (!result)
            {
                throw new Exception("Problemas al agegar al animal" + Animal.Nombre);
            }
        }

        public int Eliminar(int Id)
        {
            
                int Borrar = Data.Eliminar(Id);
                if (Borrar != 1)
                {
                    throw new Exception("Error al eliminar el animal");
                }
                return Borrar;
            
               
            }

        public void Editar(EntityAnimales Animal)
        {
            
            Data.Editar(Animal.Nombre, Animal.Tipo, Animal.Color, Animal.Edad, Animal.Id);
            
            
        }

        public List<EntityAnimales> Buscar(string Palabra)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Data.Buscar(Palabra);
                List<EntityAnimales> lista_buscar = new List<EntityAnimales>();

                foreach (DataRow dr in dt.Rows)
                {
                    EntityAnimales lista = new EntityAnimales();

                    lista.Nombre = Convert.ToString(dr["Nombre"]);
                    lista.Tipo = Convert.ToString(dr["Tipo"]);
                    lista.Color = Convert.ToString(dr["Color"]);
                    lista.Edad = Convert.ToInt32(dr["Edad"]);
                    lista.Id = Convert.ToInt32(dr["Id"]);

                    lista_buscar.Add(lista);
                }

                return lista_buscar;
            }
            catch
            {
                throw;
            }
           
        }

    }
}
