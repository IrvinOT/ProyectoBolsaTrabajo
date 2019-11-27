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
    class Conexion
    {
        public SqlConnection getConexion()
        {
            try
            {
                string cadena = "Data Source=TREJO-PC\\MSSQLSERVER01;Initial Catalog=\"Bolsa deTrabajo\";Integrated Security=True";
                SqlConnection cnn = new SqlConnection(cadena);
                cnn.Open();
                return cnn;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
