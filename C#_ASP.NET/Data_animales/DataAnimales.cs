using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Data_animales
{
    public class DataAnimales
    {
        //Conexion global a la db
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

        public DataTable Obtener()
        {
            string Query;
            Query = "select*from AnimalesDeRancho";
            DataTable Tabla = new DataTable();
            SqlDataAdapter obtener_tabla = new SqlDataAdapter(Query , Conexion);
            obtener_tabla.Fill(Tabla);

            return Tabla;
        }

        public DataRow Obtener_Id(int Id)
        {
            string Query;
            Query = $"select*from AnimalesDeRancho where id={Id}";
            DataTable Id_animal = new DataTable();
            SqlDataAdapter Animal = new SqlDataAdapter(Query , Conexion);
            Animal.Fill(Id_animal);

            return Id_animal.Rows[0];
        }

        public int Agregar(string Nombre , string Tipo , string Color , int Edad)
        {
            string Query;
            Query = $"insert into AnimalesDeRancho values('{Nombre}' , '{Tipo}' , '{Color}' , {Edad})";
            SqlCommand Agregar = new SqlCommand(Query , Conexion);
            try
            {
                Conexion.Open();
                int fila = Agregar.ExecuteNonQuery();
                Conexion.Close();
                return fila;
            }
            catch
            {
                Conexion.Close() ;
                throw;
            }
        }

        public int Eliminar(int Id)
        {
            string Query;
            Query = $"delete AnimalesDeRancho where id ={Id}";
            SqlCommand Eliminar = new SqlCommand( Query , Conexion);

            try
            {
                int fila_eliminada = 0;
                Conexion.Open();
                fila_eliminada = Eliminar.ExecuteNonQuery();
                Conexion.Close();

                return fila_eliminada;
            }
            catch 
            { 
                Conexion.Close() ;
                throw;
            }
        }

        public void Editar(String Nombre, string Tipo, string Color, int Edad, int Id)
        {
            string Query;
            Query = $"update AnimalesDeRancho set Nombre = '{Nombre}' , Tipo = '{Tipo}' , Color = '{Color}', Edad = {Edad} where Id = {Id}";
            SqlCommand editar = new SqlCommand(Query, Conexion);

            try
            {
                Conexion.Open();
                editar.ExecuteNonQuery();
                Conexion.Close();
            }
            catch
            {
                Conexion.Close();
                throw;
            }

        }


        public DataTable Buscar(string Palabra)
        {
            string Query;
            Query = $"select * from AnimalesDeRancho where Nombre like '%{Palabra}%' or Tipo like '%{Palabra}%' or Color like '%{Palabra}%'";
            DataTable tabla = new DataTable();
            SqlDataAdapter buscar = new SqlDataAdapter(Query, Conexion);
            buscar.Fill(tabla);
            return tabla;
        }

    }
}
