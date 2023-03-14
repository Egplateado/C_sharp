using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pacientes.Models
{
    public class logica
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
        
        public DataTable Obtener_tabla()
        {
            string Query;
            Query = "select * from Pacientes";
            SqlDataAdapter da = new SqlDataAdapter(Query , Conexion);
            DataTable tabla_pacientes = new DataTable();
            da.Fill(tabla_pacientes);

            return tabla_pacientes;
        }

        public void Agregar_pacientes(string Nombre_del_paciente , string Apellidos , int Edad)
        {
            //DateTime fecha = DateTime.Now; fecha con visual studio
            string Query;
            Query = $"insert into Pacientes values('{Nombre_del_paciente}' , '{Apellidos}' , {Edad} , getdate())";
            SqlCommand comando = new SqlCommand(Query, Conexion);
            try
            {
                Conexion.Open();
                comando.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception) 
            {
                Conexion.Close() ;
                throw;
            }

        }

        public bool Validar_paciente(string Nombre_del_paciente, string Apellidos, int Edad)
        {
            String Query;
            Query = $"Select 1 as Validar from Pacientes where Nombre_del_paciente ='{Nombre_del_paciente}' and Apellidos = '{Apellidos}' and Edad = {Edad}";
            SqlCommand comando = new SqlCommand(Query ,  Conexion);
            try
            {
                Conexion.Open();
                bool existe = Convert.ToBoolean(comando.ExecuteScalar());
                Conexion.Close();
                return existe;
            }
            catch (Exception) 
            {
                Conexion.Close() ;
                throw;
            }
        }

        public void Dele_paciente(int Id)
        {
            string Query;
            Query = $"delete Pacientes where Id = {Id}";
            SqlCommand comando = new SqlCommand( Query, Conexion);
            try
            {
                Conexion.Open();
                comando.ExecuteNonQuery();
                Conexion.Close();
            }

            catch(Exception ) 
            {
                Conexion.Close();
                throw;
            }

        }

        public bool Update_paciente(int Id)
        {
            string Query;
            Query $"select * from Pacientes where Nombre_del_paciente";
            SqlDataAdapter adapter = new SqlDataAdapter(Query , Conexion);


        }
    }

    }