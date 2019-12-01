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

        public int Carrera { get; set; }

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

        public List<PublicacionViewModel> listPublicaciones { get; set; }

        public int IdPublicacion { get; set; }

        public PublicacionViewModel publicacion { get; set; }

    }
    
}