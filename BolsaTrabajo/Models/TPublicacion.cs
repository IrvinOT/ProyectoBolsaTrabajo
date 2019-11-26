using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolsaTrabajo.Models
{
    public class TPublicacion
    {
        [Key]
        public int Id { get; set; }

        public string Categoria { get; set; }
        public string Empresa { get; set; }
        public string Descripcion { get; set; }
    }
}