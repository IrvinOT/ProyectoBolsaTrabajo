using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajo.Models
{
    public class PublicacionDetalladaViewModel
    {
        public int ID { get; set; }
        public string Vacante { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }
        public string Carreras { get; set; }
        public string Empresa { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}