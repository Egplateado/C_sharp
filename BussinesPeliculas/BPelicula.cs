using DataPelicula;
using EntityPelicula;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesPeliculas
{
    public class BPelicula
    {
        DPelicula data = new DPelicula();

        public List <EPelicula> Obtener()// si retorno un DT se convierte en un listado
        {
            DataTable Tabla = data.Obtener();
            List<EPelicula> list = new List<EPelicula>();
            foreach(DataRow dr in Tabla.Rows)
            {
                EPelicula pelicula = new EPelicula();

                pelicula.Id = Convert.ToInt32(dr["Id"]);
                pelicula.Nombre = Convert.ToString(dr["Nombre"]);
                pelicula.Genero = Convert.ToString(dr["Genero"]);
                pelicula.Fecha = Convert.ToDateTime(dr["Fecha_emicion"]).ToString("dd/mm//yyyy");
                pelicula.Director = Convert.ToString(dr["Director"]);

                list.Add(pelicula);
            }
            return list;
        }

        public EPelicula Obtener_id(int id)
        {
            DataRow dr = data.Obtener_id(id);

            EPelicula pelicula = new EPelicula();

            pelicula.Id = Convert.ToInt32(dr["Id"]);
            pelicula.Nombre = Convert.ToString(dr["Nombre"]);
            pelicula.Genero = Convert.ToString(dr["Genero"]);
            pelicula.Fecha = Convert.ToDateTime(dr["Fecha_emicion"]).ToString("yyyy-mm-dd");
            pelicula.Director = Convert.ToString(dr["Director"]);

             return pelicula;
        }

        public void Agregar (EPelicula pel)
        {
            int Fila_afectada = data.Agregar(pel.Nombre , pel.Genero , pel.Fecha , pel.Director);
            if(Fila_afectada != 1 )
            {
                throw new AplicationException($"Error al agregar la pelicula {pel.Nombre}");
            }
        }

        public List<EPelicula> Buscar(string Buscar)
        {
            DataTable tabla= data.Buscar(Buscar);
            List<EPelicula> lista = new List<EPelicula>();
            foreach (DataRow dr in tabla.Rows)
            {
                EPelicula pelicula= new EPelicula();


                pelicula.Id = Convert.ToInt32(dr["Id"]);
                pelicula.Nombre = Convert.ToString(dr["Nombre"]);
                pelicula.Genero = Convert.ToString(dr["Genero"]);
                pelicula.Fecha = Convert.ToDateTime(dr["Fecha_emicion"]).ToString("yyyy-mm-dd");
                pelicula.Director = Convert.ToString(dr["Director"]);

                lista.Add(pelicula);
            }
            return lista;
        }

        public void Editar (EPelicula peli)
        {
            int fa = data.Editar(peli.Nombre , peli.Genero , peli.Fecha , peli.Director , peli.Id);
            if( fa != 1 )
            {
                throw new AplicationException($"Error al elditar la pelicula {peli.Nombre}");
            }
        }

        public void Eliminar(EPelicula pel)
        {
            int Fila_afectada = data.Eliminar(pel.Id);
            if (Fila_afectada != 1)
            {
                throw new AplicationException($"Error aleliminar la pelicula {pel.Nombre}");
            }
        }

    }
}
