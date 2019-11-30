using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajo.Models
{
    public class PublicacionViewModel
    {
        public string Vacante { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos{ get; set; }
        public string Carreras { get; set; }

    }
}