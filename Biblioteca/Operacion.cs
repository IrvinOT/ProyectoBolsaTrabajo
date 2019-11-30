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
                SqlCommand cmd = new SqlCommand(query, con);
                int n = cmd.ExecuteNonQuery();
                con.Close();

                return n > 0;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return false;
            }
        }
        public int LeerEntero(string query)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            con.Open();
            int idEmpresa = -1;
            try
            {
                
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
                con.Close();
                e.Message.ToString();
                return idEmpresa;
            }
            
        }

        public string LeerString(string query)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            con.Open();
            string idEmpresa = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    idEmpresa = resultado.GetString(0);
                }

                con.Close();
                return idEmpresa;
            }
            catch (Exception e)
            {
                con.Close();
                e.Message.ToString();
                return idEmpresa;
            }
            
        }

        public List<string> leerUsuario(string correo, string pass)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            con.Open();
            List<string> lista = new List<string>();
            try {
                string query =String.Format("Select U.IdUsuario, U.Correo, U.Passwor, Em.Nombre " +
                    "from Usuarios as U Inner Join Empleado as E ON U.IdUsuario = E.idUsuario "+
                       " INNER JOIN Empresa Em ON E.Empresa = Em.ID"+
                   " where U.Correo = '{0}' and U.Passwor = '{1}'; ", correo, pass);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    lista.Clear();
                    string id = ""+resultado.GetInt32(0);
                    lista.Add(id); // idUsuario
                    lista.Add(resultado.GetString(1)); // Correo
                    lista.Add(resultado.GetString(2)); // Password 
                    lista.Add("Empleado");
                    lista.Add(resultado.GetString(3));
                }
                con.Close();
                
                if(lista.Count <= 0)
                {
                    con.Open();
                     query = String.Format("select U.IdUsuario, U.Correo, U.Passwor from Usuarios as U Inner Join Alumno as E ON U.IdUsuario = E.idUsuario"+
                               " where U.Correo ='{0} && U.Passwor = '{1}'; ", correo, pass);
                     cmd = new SqlCommand(query, con);
                     resultado = cmd.ExecuteReader();
                    while (resultado.Read())
                    {
                        lista.Clear();
                        string id = "" + resultado.GetInt32(0);
                        lista.Add(id); // idUsuario
                        lista.Add(resultado.GetString(1)); // Correo
                        lista.Add(resultado.GetString(2)); // Password 
                        lista.Add("Alumno");
                    }
                }
                con.Close();
                return lista;
            } catch(Exception e)
            {
                e.Message.ToString();
                return lista;
            }
          
            
        }
    }

}
