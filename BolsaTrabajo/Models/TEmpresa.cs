using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolsaTrabajo.Models
{
    public class TEmpresa
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Giro { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
    }
}