using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Biblioteca
{
   public class Operacion
    {
        public bool insertar(string query)
        {
            Conexion conexion = new Conexion();
            try
            {
                SqlConnection con = conexion.cnn;
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                int n = cmd.ExecuteNonQuery();
                con.Close();
               
                return n > 0;
            }
            catch(Exception e)
            {
                e.Message.ToString();
                return false;
            }
        }
        public int LeerEmpresa(string query)
        {
            Conexion conexion = new Conexion();
            int idEmpresa = -1;
            try
            {
                SqlConnection con = conexion.cnn;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    idEmpresa = resultado.GetInt32(0);
                }
                con.Close();

               return idEmpresa;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return  -1;
            }
        }
    }

}
