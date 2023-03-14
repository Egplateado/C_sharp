using CRUD_Medicamentos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_Medicamentos.Models
{

    public class data
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
        
        public DataTable Obtener_tabla()
        {
            String Query;
            Query = "select * from Medicamentos";
            SqlDataAdapter adapter = new SqlDataAdapter(   Query , Conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        
        public void Agregar_medicamento(Medicamento medicamento)
        {
            string Query;
            Query = $"insert into Medicamentos values('{medicamento.Nombre}' , '{medicamento.Tipo}' , '{medicamento.Fecha}' , {medicamento.Precio})  ";
            SqlCommand insertar = new SqlCommand(Query , Conexion);
            try
            {
                Conexion.Open();
                insertar.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception) 
            {
                Conexion.Close();
                throw;
            }
        }

        public void Eliminar(int Id)
        {
            try
            {
                string Query;
                Query = $"delete Medicamentos where Id_medicamento ={Id}";
                SqlCommand eliminar = new SqlCommand(Query, Conexion);
                Conexion.Open();
                eliminar.ExecuteNonQuery();
                Conexion.Close() ;
            }
            catch (Exception)
            {
                Conexion.Close();
                throw;
            }
        }

        public bool Editar_validar(Medicamento med)
        {
            string Query;
            Query = $"Select * from Medicamentos where Nombre_del_medicamento = '{med.Nombre}'  and Tipo_del_medicamento = '{med.Tipo}' and Id_medicamento != {med.Id}";
            SqlDataAdapter traer_medicamento = new SqlDataAdapter(Query, Conexion);
           DataTable medicamento = new DataTable();
            traer_medicamento.Fill(medicamento);
            try
            {
                if(medicamento.Rows.Count > 0)
                {
                    return true;
                }

                else 
                { return false; }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Editar(Medicamento med)
        {
            string Query;
            Query = $"update Medicamentos set Nombre_del_medicamento = '{med.Nombre}' , Tipo_del_medicamento = '{med.Tipo}' ,Precio = {med.Precio} where Id_medicamento = {med.Id}";
            SqlCommand actualizar = new SqlCommand(Query, Conexion);
            try
            {
                Conexion.Open();
                actualizar.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception)
            {
                Conexion.Close();
                throw;
            }
        }

        public DataRow Fila(int Id)
        {
            string Query = $"select * from Medicamentos where Id_medicamento={Id}";
            SqlDataAdapter traer_fila = new SqlDataAdapter(Query, Conexion);
            DataTable fila = new DataTable();
            traer_fila.Fill(fila);
            DataRow FILA_ID = fila.Rows[0];
            return FILA_ID;
        }
        
    }

    
}