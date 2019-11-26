using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajo.Models
{
    public class CarrerasViewModel
    {

        public string Carrera { get; set; }

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
                    new SelectListItem {Text = "Gestion Empresarial", Value="Gestion Empresarial" },

                };
            }
        }
    }
}