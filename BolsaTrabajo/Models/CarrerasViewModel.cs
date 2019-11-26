using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajo.Models
{
    public class CarrerasViewModel
    {

        public string Carrera { get; set; }

         [Required]
         [EmailAddress]
         public string Email { get; set; }

         [Required]
         [DataType(DataType.Password)]
         public string Password { get; set; }



        public IEnumerable<SelectListItem> ListaCarreras { get {
                return new List<SelectListItem>
                {
                    new SelectListItem {Text = "Sistemas Computacionales", Value="Sistemas Computacionales" },
                    new SelectListItem {Text = "Mecatronica", Value="Mecatronica" },
                    new SelectListItem {Text = "Logistica", Value="Logistica" },
                    new SelectListItem {Text = "Industrial", Value="Industrial" },
                    new SelectListItem {Text = "Gestion Empresarial", Value="Gestion Empresarial" }
                };
            }
        }

        public IEnumerable<SelectListItem> ListaSectores
        {
            get
            {
                return new List<SelectListItem> {
                    new SelectListItem{Text = "" }
                };
            }
        }

        public string NombreEmp { get; set; }
        public string RazonEmp { get; set; }
        public string GiroEmp { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Cp { get; set; }
        public string Ciudad { get; set; }
        public string TelefonoD { get; set; }
        public string NombreE { get; set; }
        public string DependenciaE { get; set; }
        public string PuestoE { get; set; }
        public string CorreoE { get; set; }
        public string PassE { get; set; }
        public string PassEC { get; set; }
        public string TelefonoE { get; set; }
    }
    
}