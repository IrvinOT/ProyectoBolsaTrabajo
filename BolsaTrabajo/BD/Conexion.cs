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
        public Conexion()
        {
                string cadena = "Data Source=TREJO-PC\\MSSQLSERVER01;Initial Catalog=\"Bolsa deTrabajo\";Integrated Security=True";
                cnn = new SqlConnection(cadena);
          
        }

        public SqlConnection cnn { get;}

        public SqlCommand comand { get; set; }
    }
}
