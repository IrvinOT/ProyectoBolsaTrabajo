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
    class Operacion
    {
        public bool Insertar(string query)
        {
            Conexion cn = new Conexion();
            try
            {
                SqlCommand cmd = new SqlCommand(query,cn.getConexion());
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
