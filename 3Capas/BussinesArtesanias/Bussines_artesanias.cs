using DataArtesanias;
using EntityArtesanias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesArtesanias
{
    public class Bussines_artesanias    
    {
        Data_artesanias  data = new Data_artesanias();

        public List<Entity_artesanias> Obtener()
        {
            DataTable lista = data.Obtener();
            List<Entity_artesanias> Lista_artesania = new List<Entity_artesanias>();
            foreach (DataRow fila in lista.Rows)
            {
                Entity_artesanias Artesania = new Entity_artesanias();
                Artesania.Id = Convert.ToInt32(fila["ID"]);
                Artesania.Nombre = Convert.ToString(fila["Nombre"]);
                Artesania.Color = Convert.ToString(fila["Color"]);
                Artesania.Unidades = Convert.ToInt32(fila["Unidades"]);
                Artesania.Precio = Convert.ToInt32(fila["Precio"]);

                Lista_artesania.Add(Artesania);
            }
            return Lista_artesania;
        }

        public Entity_artesanias Obtener_id(int Id)
        {
            DataRow Id_dr = data.Obtener_id(Id);

            Entity_artesanias Artesania = new Entity_artesanias();


            Artesania.Id = Convert.ToInt32(Id_dr["Id"]);
            Artesania.Nombre = Convert.ToString(Id_dr["Nombre"]);
            Artesania.Color = Convert.ToString(Id_dr["Color"]);
            Artesania.Unidades = Convert.ToInt32(Id_dr["Unidades"]);
            Artesania.Precio = Convert.ToInt32(Id_dr["Precio"]);

            return Artesania;
        }

        public void Agregar(Entity_artesanias data_artesania)
        {
            int Fila_agregada = data.Agregar(data_artesania.Nombre , data_artesania.Color , data_artesania.Unidades , data_artesania.Precio);
            if(Fila_agregada != 1)
            {
                throw new ApplicationException($"Error al agregar{data_artesania.Nombre}");
            }
        }

        public void Eliminar(Entity_artesanias artesania)
        {
            int Fila_eliminada = data.Eliminar(artesania.Id);
            if(Fila_eliminada != 1)
            {
               throw new ApplicationException($"Error al eliminar la artesania {artesania.Nombre}");
            }
        }

        public void Editar(Entity_artesanias Artesania)
        {
            
            int fila_editada = data.Editar(Artesania.Nombre, Artesania.Color, Artesania.Unidades, Artesania.Precio, Artesania.Id);
            if(fila_editada != 1)
            {
                throw new ApplicationException($"Error al editar {Artesania.Nombre}");
            }
        }

        public List<Entity_artesanias> Buscar(string Data)
        {
            DataTable Buscar = data.Buscar(Data);
            List<Entity_artesanias> lista = new List<Entity_artesanias>();
            foreach( DataRow dr in Buscar.Rows)
            {
                Entity_artesanias artesanias = new Entity_artesanias();
                artesanias.Id = Convert.ToInt32(dr["ID"]);
                artesanias.Nombre = Convert.ToString(dr["Nombre"]);
                artesanias.Color = Convert.ToString(dr["Color"]);
                artesanias.Unidades = Convert.ToInt32(dr["Unidades"]);
                artesanias.Precio = Convert.ToInt32(dr["Precio"]);

                lista.Add(artesanias);
            }

            return lista;
        }

       
    }
}
