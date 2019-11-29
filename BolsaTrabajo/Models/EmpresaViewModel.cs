using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolsaTrabajo.Models
{
    public class EmpresaViewModel
    {
        [Required]
        public string NombreEmp { get; set; }
        [Required]
        public string RazonEmp { get; set; }
        [Required]
        public string GiroEmp { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string Colonia { get; set; }
        [Required]
        public string Cp { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string TelefonoD { get; set; }
        [Required]
        public string NombreE { get; set; }
        [Required]
        public string ApellidoP { get; set; }
        [Required]
        public string ApellidoM { get; set; }
        [Required]
        public string DependenciaE { get; set; }
        [Required]
        public string PuestoE { get; set; }
        [Required]
        public string CorreoE { get; set; }
        [Required]
        public string PassE { get; set; }
        [Required]
        public string PassEC { get; set; }
        [Required]
        public string TelefonoE { get; set; }
        [Required]
        public string PuestoP { get; set; }
        [Required]
        public string DescrP { get; set; }
        [Required]
        public string RequP { get; set; }
        [Required]
        public string CarerrasP { get; set; }
    }
}