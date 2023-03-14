using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;



namespace Ganaderias.Models
{
    public class logica
    {
        public DataTable get()
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = "select * from Ranchos";
            SqlDataAdapter data = new SqlDataAdapter(query , Connection_to_ranchos);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        public void Agregar_Rancho(string Nombre_del_Rancho, string Nombre_del_Dueño, int N_de_Toros, string Ubicacion_del_rancho)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"insert into Ranchos values('{Nombre_del_Rancho}' , '{Nombre_del_Dueño}' , {N_de_Toros}  , '{Ubicacion_del_rancho}' )";
            SqlCommand command = new SqlCommand(query , Connection_to_ranchos);
            Connection_to_ranchos.Open();
            command.ExecuteNonQuery();
            Connection_to_ranchos .Close();
        }

        public DataRow Obtener_Id(int Id)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"select * from Ranchos where Id_Ranchos ={Id}";
            SqlDataAdapter Data_Adapter = new SqlDataAdapter(query, Connection_to_ranchos);
            DataTable Data_Table = new DataTable();
            Data_Adapter.Fill(Data_Table);
            DataRow Data_Row = Data_Table.Rows[0];

            return Data_Row;
        }

        public void Update(string Nombre_del_Rancho, string Nombre_del_Dueño, int N_de_Toros, string Ubicacion_del_rancho , int ID)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"update Ranchos set Nombre_del_Rancho = '{Nombre_del_Rancho}' , Nombre_del_Dueño ='{Nombre_del_Dueño}' , N_de_toros ={N_de_Toros} , Ubicacion_del_Rancho = '{Ubicacion_del_rancho}' where Id_Ranchos = {ID}";
            SqlCommand command = new SqlCommand(query ,Connection_to_ranchos);
            Connection_to_ranchos.Open();
            command.ExecuteNonQuery();
            Connection_to_ranchos.Close();
        }

        public void Eliminar(int ID)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"delete Ranchos where Id_Ranchos = {ID}";
            SqlCommand borrar = new SqlCommand(query , Connection_to_ranchos);
            Connection_to_ranchos .Open(); 
            borrar.ExecuteNonQuery();
            Connection_to_ranchos.Close ();
        }

        public DataTable Buscar(string data)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"select * from Ranchos where Nombre_del_Rancho like '%{data}%' or Ubicacion_del_Rancho like '%{data}%'";
            SqlDataAdapter data_adapter = new SqlDataAdapter(query , Connection_to_ranchos);
            DataTable dt = new DataTable();
            data_adapter.Fill(dt);
            return dt;
        }

        public bool Validar_Agregar(string Nombre_del_Rancho , string Nombre_del_Dueño)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"select * from Ranchos where Nombre_del_Rancho='{Nombre_del_Rancho}' and Nombre_del_Dueño ='{Nombre_del_Dueño}'";
            SqlDataAdapter data_adapter = new SqlDataAdapter(query, Connection_to_ranchos);
            DataTable dt = new DataTable();
            data_adapter.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool Validar_editar(string Nombre_del_Rancho, string Nombre_del_Dueño ,  int Id)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = Ganaderias; user id = sa; password = 21Plateado";
            SqlConnection Connection_to_ranchos = new SqlConnection(cadena);
            string query = $"select * from Ranchos where Nombre_del_Rancho='{Nombre_del_Rancho}' and Nombre_del_Dueño ='{Nombre_del_Dueño}' and Id_Ranchos!={Id}";
            SqlDataAdapter data_adapter = new SqlDataAdapter(query, Connection_to_ranchos);
            DataTable dt = new DataTable();
            data_adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}