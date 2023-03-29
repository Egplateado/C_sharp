using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataArtesania
{
    public class Data_artesania
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

        public DataTable Obtener()
        {
            string Query;
            Query = "select*from Artesanias";
            SqlDataAdapter obtener = new SqlDataAdapter(Query , Conexion);
            DataTable tabla_obtener = new DataTable();
            obtener.Fill(tabla_obtener);

            return tabla_obtener;
        }

        public DataRow Obtener_id(int Id)//obtener vista editarget
        {
            string Query;
            Query = $"select*from Artesanias where Id ={Id}";
            SqlDataAdapter Obtener_id = new SqlDataAdapter(Query , Conexion);
           DataTable Fila_id = new DataTable();
           Obtener_id.Fill( Fila_id );

            return Fila_id.Rows[0];
        }

        public int Agregar(string Nombre , string Color , int Unidades , int Precios)
        {
            string Query;
            Query = $"insert into Artesanias values('{Nombre}', '{Color}' , '{Unidades}' , {Precios})";
            SqlCommand insertar = new SqlCommand(Query, Conexion);
            try
            {
                Conexion.Open();
                int Fila_afectada = insertar.ExecuteNonQuery();
                Conexion.Close();

                return Fila_afectada;
            }
            catch
            {
                Conexion.Close();
                throw;
            }
        }
    }
}
