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



        public IEnumerable<SelectListItem> ListaCarreras
        {
            get
            {
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
                    new SelectListItem{Text = "Agricultura", Value="Agricultura" },
                    new SelectListItem{Text = "Alimentación",Value="Alimentación"},
                    new SelectListItem{Text = "Comercio",Value="Comercio"},
                    new SelectListItem{Text = "Construcción",Value= "Construcción"},
                    new SelectListItem{Text = "Educación", Value="Educación"},
                    new SelectListItem{Text = "Fabricación", Value= "Fabricación" },
                    new SelectListItem{Text = "Función pública", Value="Función pública" },
                    new SelectListItem{Text = "Hotelería, restauración, turismo", Value="Hotelería, restauración, turismo" },
                    new SelectListItem{Text = "Industrias químicas", Value="Industrias químicas" },
                    new SelectListItem{Text = "Ingenieria mecánica y eléctria", Value = "Ingenieria mecánica y eléctria" },
                    new SelectListItem{Text = "Medios de comunicación",Value = "Medios de comunicación" },
                    new SelectListItem{Text = "Minería", Value="Minería" },
                    new SelectListItem{Text = "Petroleo y producción de gas",Value="Petroleo y producción de gas" },
                    new SelectListItem{Text = "Producción de metales básicos",Value="Producción de metales básico" },
                    new SelectListItem{Text = "Servicios de correos y de telecomunicaciones",Value="Servicios de correos y de telecomunicaciones" },
                    new SelectListItem{Text = "Servicios de salud",Value="Servicios de salud" },
                    new SelectListItem{Text = "Servicios financieros",Value="Servicios financieros" },
                    new SelectListItem{Text = "Servicios públicos",Value="Servicios públicos" },
                    new SelectListItem{Text = "Silvicultura",Value="Silvicultura" },
                    new SelectListItem{Text = "Textiles",Value="Textiles" },
                    new SelectListItem{Text = "Transporte(inluyendo aviación civil; ferrocarriles",Value="Transporte(inluyendo aviación civil; ferrocarrile" },
                    new SelectListItem{Text = "Transporte marítimo",Value="Transporte marítimo" }
                    };
            }
        }

        public List<PublicacionViewModel> listPublicaciones { get; set; }

        public int IdPublicacion { get; set; }

        public PublicacionViewModel publicacion { get; set; }

        public List<PublicacionDetalladaViewModel> listPublicacionesDetallada
        {
            get
            {
                return new Biblioteca.Operacion().leerPublicacionesDet();
            }
        }

        public PublicacionDetalladaViewModel publicacionDetallada { get; set; }

    }

}