using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class PublicacionProvisional
    {
        public int Id { get; set; }
        public string Vacante { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }
        public List<string> Carreras { get; set; }
    }
}
