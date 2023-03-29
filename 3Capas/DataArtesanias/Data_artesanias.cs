using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataArtesanias
{
    public class Data_artesanias
    {
        //CoNEXION GLOBAL 
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

        //Metodo Obtener

        public DataTable Obtener()
        {
            string Query;
            Query = "select*from Artesanias";
            SqlDataAdapter Obtener_tabla = new SqlDataAdapter(Query , Conexion);
            DataTable Tabla = new DataTable();
            Obtener_tabla.Fill(Tabla);

            return Tabla;
        }

        public DataRow Obtener_id(int Id)
        {
            string Query;
            Query = $"select*from Artesanias where Id ={Id}";
            SqlDataAdapter Obtener_id_fila = new SqlDataAdapter(Query, Conexion);
            DataTable Fila_id = new DataTable();
            Obtener_id_fila.Fill(Fila_id);

            return Fila_id.Rows[0];
        }

        //poner un objeto de entity y llamarlo en agregar(argumentos)
        public int Agregar(string Nombre, string Color, int Unidades, int Precio)
        {
            String Query;
            Query = $"insert into Artesanias values('{Nombre}' , '{Color}' , {Unidades} , {Precio})";
            SqlCommand Insertar = new SqlCommand(Query, Conexion);
            try
            {
                Conexion.Open();
                int Fila_afectada = Insertar.ExecuteNonQuery();
                Conexion.Close();

                return Fila_afectada;
            }
            catch
            {
                Conexion.Close();
                throw;
            }
        }

        public int Eliminar(int Id)
        {
            String Query;
            Query = $"delete Artesanias where Id = {Id}";
            SqlCommand Eliminar_artesania = new SqlCommand(Query, Conexion);
            try
            {
                Conexion.Open();
                int Fila_eliminada = Eliminar_artesania.ExecuteNonQuery();
                Conexion.Close();

                return Fila_eliminada;
            }
            catch
            {
                Conexion.Close();
                throw;
            }
        }

        public int Editar(string Nombre, string Color, int Unidades, int Precio , int Id)
        {
            String Query;
            Query = $"update Artesanias set Nombre = '{Nombre}' ,Color = '{Color}' , Unidades = {Unidades} , Precio = {Precio} where Id = {Id}";
            SqlCommand Editar = new SqlCommand( Query, Conexion);
            try
            {
                Conexion.Open();
                int fila_editada = Editar.ExecuteNonQuery();
                Conexion.Close();

                return fila_editada;
            }

            catch (Exception)
            {
                Conexion.Close();
                throw;
            }

        }

        public DataTable Buscar (string Data)
        {
            string Query;
            Query = $"select * from Artesanias where Nombre like '%{Data}%' or Color like '%{Data}%' ";
            SqlDataAdapter Buscar = new SqlDataAdapter(Query , Conexion);
            DataTable dataTable = new DataTable();
            Buscar.Fill(dataTable);
            return dataTable;
        }
        
    }
}
