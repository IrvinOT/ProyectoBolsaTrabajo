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
        public ActionResult Modificar()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]

        public ActionResult AdminPublicacion()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Publicacion()
        {
            var U =  new UsuarioViewModel
            {
                IdUsuario = 1,
                Empresa = "Calcetines SA"
            };
            TempData["Usuario"] = U;
            return View();
        }
        [HttpPost]
        public ActionResult Publicacion(PublicacionViewModel m)
        {
            var s = 12;
            //if (TempData.ContainsKey("Usuario")) {
                var u = TempData["Usuario"] as UsuarioViewModel;
                Operacion opBD = new Operacion();
               string sql = String.Format("INSERT INTO [dbo].[Publicacion] ([Empresa],[Descricpion],[Vacante],[Requisitos],[IdEmpleado])"
                  + " VALUES('{0}', '{1}', '{2}', '{3}', {4})",u.Empresa, m.Descripcion, m.Vacante, m.Requisitos, u.IdUsuario);
            opBD.insertar(sql);
                int id = opBD.LeerEntero("Select * from Publicacion");
                List<String> listaCarreras = opBD.carreras(m.Carreras);
                foreach (var carr in listaCarreras)
                {
                    sql = String.Format("INSERT INTO [dbo].[Categoria] ([IdPublicacion],[Carrera])" +
                       " VALUES({0},'{1}')", id, carr);
                    opBD.insertar(sql);
                }
                TempData["Usuario"] = u;
            return View();
            }
            //else
            //{
            //    return View("Login", "Cuenta");
            //}
        

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }
    }
}