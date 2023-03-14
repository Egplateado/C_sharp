using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace crud_1.Models
{
    public class logica
    {
        public DataTable Get()
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = G19; user id = sa; password = 21Plateado";
            SqlConnection connection = new SqlConnection(cadena);//conectio to db
            string query = "Select * From personas";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public void Agregar(string Nombre, string A_paterno, string A_materno, int Edad)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = G19; user id = sa; password =21Plateado ";
            SqlConnection connection = new SqlConnection(cadena);//conectio to db
            string query = $"insert into personas values ('{Nombre}' , '{A_paterno}' , '{A_materno}' , {Edad})";
            SqlCommand com = new SqlCommand(query, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(string Nombre, string A_paterno , string A_materno , int Edad , int id) 
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = G19; user id = sa; password =21Plateado ";
            SqlConnection connection = new SqlConnection(cadena);//conectio to db
            string query = $"update personas set nombre = '{Nombre}' ,A_paterno ='{A_paterno}' , A_materno = '{A_materno}' ,Edad = {Edad}  WHERE id_persona = {id}";
            SqlCommand com = new SqlCommand(query, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
        }

        public DataRow Obtener_id(int id) 
        {

            string cadena = "server = DESKTOP-8AD8FR5; Database = G19; user id = sa; password =21Plateado ";
            SqlConnection connection = new SqlConnection(cadena);//conectio to db
            string query = $"select * from personas where id_persona = {id}";
            SqlDataAdapter da  = new SqlDataAdapter(query , connection);
            DataTable td = new DataTable();
            da.Fill(td);
            DataRow dr = td.Rows[0];
            return dr;
        }

        public void Eliminar(int id)
        {
            string cadena = "server = DESKTOP-8AD8FR5; Database = G19; user id = sa; password =21Plateado ";
            SqlConnection connection = new SqlConnection(cadena);//conectio to db
            string query = $"delete personas where id_persona = {id}";
            SqlCommand com = new SqlCommand(query , connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
        }
    }
}