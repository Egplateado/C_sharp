using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataPelicula
{
    public class DPelicula
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
    
        public DataTable Obtener()
        {
            String Query;
            Query = $"select * from Peliculas";
            SqlDataAdapter adapter = new SqlDataAdapter( Query ,Conexion);
            DataTable Obtener = new DataTable();
            adapter.Fill( Obtener );

            return Obtener;
        }

        public DataRow Obtener_id(int id)//metodo para la vista de editar
        {
             string Query = $"select * from Peliculas where Id={id}";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Conexion);
            DataTable Obtener = new DataTable();
            adapter.Fill(Obtener);

            return Obtener.Rows[0];
        }

        public int Agregar (string Nombre , string Genero , string Fecha , string Director)
        {
            string Query;
            Query = $"insert into Peliculas values('{Nombre}' , '{Genero}' , '{Fecha}' , '{Director}')";
            SqlCommand agregar = new SqlCommand(Query , Conexion );
            try
            {
                Conexion.Open();
                int Fila_afectada = agregar.ExecuteNonQuery();
                Conexion.Close();

                return Fila_afectada;

            }
            catch
            {
                Conexion.Close();
                throw;
            }
        }

        public int Editar(string Nombre, string Genero, string Fecha, string Director, int Id)
        {
            string query = $"update Peliculas set Nombre = '{Nombre}' , Genero = '{Genero}', Fecha_emicion = '{Fecha}' , Director = '{Director}' where id ={Id}" ;
            SqlCommand comand = new SqlCommand (query , Conexion );
            try
            {
                Conexion.Open();
                int Fila_afectada = comand.ExecuteNonQuery();
                Conexion.Close();
                return Fila_afectada;
            }
            catch(Exception)
            { 
                Conexion.Close(); 
                throw; 
            }
        }

        public int Eliminar(int Id)
        {
            string Query;
            Query = $"delete Peliculas where Id ={Id}";
            SqlCommand eliminar = new SqlCommand(Query , Conexion );
            try
            {
                Conexion.Open();
                int Fila_afectada = eliminar.ExecuteNonQuery();
                Conexion.Close();
                return Fila_afectada;
            }

            catch(Exception)
            {
                Conexion.Close ();
                throw;
            }
        }

        public DataTable Buscar(string valor)
        {
            string Query;
            Query = $"select * from Peliculas where Nombre like '%{valor}%' or Genero like'%{valor}%'";
            DataTable tabla = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Query, Conexion);
            da.Fill(tabla); 
            return tabla;
        }
    }
}
