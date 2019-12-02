using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BolsaTrabajo.Models;

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
            try
            {
                string query = String.Format("Select U.IdUsuario, U.Correo, U.Passwor, Em.Nombre " +
                    "from Usuarios as U Inner Join Empleado as E ON U.IdUsuario = E.idUsuario " +
                       " INNER JOIN Empresa Em ON E.Empresa = Em.ID" +
                   " where U.Correo = '{0}' and U.Passwor = '{1}'; ", correo, pass);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    lista.Clear();
                    string id = "" + resultado.GetInt32(0);
                    lista.Add(id); // idUsuario
                    lista.Add(resultado.GetString(1)); // Correo
                    lista.Add(resultado.GetString(2)); // Password 
                    lista.Add("Empleado");
                    lista.Add(resultado.GetString(3));
                }
                con.Close();

                if (lista.Count <= 0)
                {
                    con.Open();
                    query = String.Format("select U.IdUsuario, U.Correo, U.Passwor from Usuarios as U Inner Join Alumno as E ON U.IdUsuario = E.idUsuario" +
                              " where U.Correo ='{0}' and U.Passwor = '{1}'; ", correo, pass);
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
            }
            catch (Exception e)
            {
                con.Close();
                e.Message.ToString();
                return lista;
            }


        }

        public List<PublicacionViewModel> leerPublicaciones(int idUsuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            List<PublicacionViewModel> listaPublicaciones = new List<PublicacionViewModel>();
            con.Open();
            try
            {
                string sq = String.Format("Select ID,Vacante,Descricpion,Requisitos from Publicacion where IdEmpleado = {0}", idUsuario);
                SqlCommand cmd = new SqlCommand(sq, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    int id = resultado.GetInt32(0);
                    string carrer = campoCarreras(id);
                    listaPublicaciones.Add(new PublicacionViewModel {
                        ID = id,
                        Vacante = resultado.GetString(1),
                        Descripcion = resultado.GetString(2),
                        Requisitos = resultado.GetString(3),
                        Carreras = carrer
                    });
                }
                con.Close();
                return listaPublicaciones;

            }
            catch (Exception e)
            {
                con.Close();
                return null;
            }
        }

        public List<PublicacionDetalladaViewModel> leerPublicacionesDet()
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            List<PublicacionDetalladaViewModel> listaPublicaciones = new List<PublicacionDetalladaViewModel>();
            con.Open();
            try
            {
                string sq = " Select pb.ID, pb.Vacante, pb.Descricpion,pb.Requisitos,pb.Empresa,us.Correo,Em.Telefono" +
                            " from Publicacion As pb Inner Join Empleado as Em On pb.IdEmpleado = Em.idEmpleado" +
                            " INNER JOIN Usuarios us on Em.IdUsuario = us.IdUsuario";
                SqlCommand cmd = new SqlCommand(sq, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    int id = resultado.GetInt32(0);
                    string carrer = campoCarreras(id);
                    listaPublicaciones.Add(new PublicacionDetalladaViewModel {
                        ID = id,
                        Vacante = resultado.GetString(1),
                        Descripcion = resultado.GetString(2),
                        Requisitos = resultado.GetString(3),
                        Empresa = resultado.GetString(4),
                        Correo = resultado.GetString(5),
                        Telefono = resultado.GetString(6),
                        Carreras = carrer
                    });
                }
                con.Close();
                return listaPublicaciones;

            }
            catch (Exception e)
            {
                con.Close();
                return null;
            }
        }

        public PublicacionViewModel leerPublicacion(int idPublicacion)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
           PublicacionViewModel publicacion = null;
            con.Open();
            try
            {
                string sq = String.Format("Select ID,Vacante,Descricpion,Requisitos from Publicacion where ID = {0}", idPublicacion);
                SqlCommand cmd = new SqlCommand(sq, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    int id = resultado.GetInt32(0);
                    string carrer = campoCarreras(id);
                    publicacion = new PublicacionViewModel
                    {
                        ID = id,
                        Vacante = resultado.GetString(1),
                        Descripcion = resultado.GetString(2),
                        Requisitos = resultado.GetString(3),
                        Carreras = carrer
                    };
                }
                con.Close();
                return publicacion;

            }
            catch (Exception e)
            {
                con.Close();
                return null;
            }
        }

        public PublicacionDetalladaViewModel leerPublicacionDetallada(int idPublicacion)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            PublicacionDetalladaViewModel publicacion = null;
            con.Open();
            try
            {
                string sq = String.Format(" Select pb.ID, pb.Vacante, pb.Descricpion, pb.Requisitos, pb.Empresa, us.Correo, Em.Telefono" +
                            " from Publicacion As pb Inner Join Empleado as Em On pb.IdEmpleado = Em.idEmpleado" +
                            " INNER JOIN Usuarios us on Em.IdUsuario = us.IdUsuario where pb.ID = {0}", idPublicacion);
                SqlCommand cmd = new SqlCommand(sq, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    int id = resultado.GetInt32(0);
                    string carrer = campoCarreras(id);
                    publicacion = new PublicacionDetalladaViewModel
                    {
                        ID = id,
                        Vacante = resultado.GetString(1),
                        Descripcion = resultado.GetString(2),
                        Requisitos = resultado.GetString(3),
                        Empresa = resultado.GetString(4),
                        Correo = resultado.GetString(5),
                        Telefono = resultado.GetString(6),
                        Carreras = carrer
                    };
                }
                con.Close();
                return publicacion;

            }
            catch (Exception e)
            {
                con.Close();
                return null;
            }
        }

        public List<String> carreras(string carrera)
        {
            if(carrera != null) { 
            Char[] arr = carrera.ToCharArray();
            string carr = string.Empty;
            List<String> listCarreas = new List<string>();
            foreach (var ch in arr)
            {
                if (ch == Char.Parse(","))
                {
                    listCarreas.Add(carr);
                    carr = string.Empty;
                }
                else
                {
                    carr += ch;
                }
            }

            return listCarreas;
            }
            return null;

        }

        public string campoCarreras(int idPublicacion)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.cnn;
            string sCarreras = string.Empty;
            con.Open();
            try
            {
                string sq = String.Format("Select Carrera from Categoria where IdPublicacion = {0};", idPublicacion);
                SqlCommand cmd = new SqlCommand(sq, con);
                SqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    sCarreras += resultado.GetString(0) + ",";
                }
                con.Close();
                return sCarreras;
            }
            catch (Exception e)
            {
                con.Close();
                return "";
            }
        }
    }

}
