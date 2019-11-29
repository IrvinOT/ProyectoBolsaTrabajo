using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajo.Models
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
    }
}