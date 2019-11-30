using Biblioteca;
using BolsaTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Publicacion");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Publicacion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Publicacion(PublicacionViewModel m)
        {
            //u = usuario m = modelo
            if (TempData.ContainsKey("Usuario")) {
                var u = TempData["Usuario"] as UsuarioViewModel;
                Operacion opBD = new Operacion();
                string sql = String.Format("INSERT INTO [dbo].[Publicacion] ([Carreras],[Empresa],[Descricpion],[Vacante],[Requisitos],[IdEmpleado])"
                    +" VALUES('{0}', '{1}', '{2}', '{3}', '{4}',{5})", m.Carreras, u.Empresa, m.Descripcion, m.Vacante, m.Requisitos, u.IdUsuario);


            return View();
            }
            else
            {
                return View("Login", "Cuenta");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }
    }
}