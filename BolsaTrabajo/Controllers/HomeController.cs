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
            return View();
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
        [HttpGet]
        public ActionResult Publicacion()
        {
            var U = new UsuarioViewModel
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
            //if (TempData.ContainsKey("Usuario")) {
            var u = TempData["Usuario"] as UsuarioViewModel;
            Operacion opBD = new Operacion();
            string sql = String.Format("INSERT INTO [dbo].[Publicacion] ([Empresa],[Descricpion],[Vacante],[Requisitos],[IdEmpleado])"
               + " VALUES('{0}', '{1}', '{2}', '{3}', {4})", u.Empresa, m.Descripcion, m.Vacante, m.Requisitos, u.IdUsuario);
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
            return RedirectToAction("AdminPublicacion");
        }

        [HttpGet]
        public ActionResult AdminPublicacion()
        {
            var U = new UsuarioViewModel
            {
                IdUsuario = 1,
                Empresa = "Calcetines SA"
            };

            TempData["Usuario"] = U;
            Operacion opBd = new Operacion();
            var modelo = new CarrerasViewModel
            {
                listPublicaciones = opBd.leerPublicaciones(U.IdUsuario)
            };

            TempData["Usuario"] = U;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult AdminPublicacion(CarrerasViewModel m)
        {
            Operacion opBd = new Operacion();
            var u = TempData["Usuario"] as UsuarioViewModel;
            TempData["Usuario"] = u;
            m.publicacion = opBd.leerPublicacion(m.IdPublicacion);
            TempData["Publicacion"] = m;
            return RedirectToAction("Modificar");
        }

        [HttpGet]
        public ActionResult Modificar()
        {
            if(TempData.ContainsKey("Publicacion")) {
               var m = TempData["Publicacion"] as CarrerasViewModel;
               TempData["Publicacion"] = m;
                return View(m);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(CarrerasViewModel m)
        {

            var u = TempData["Usuario"] as UsuarioViewModel;
            var mAnterior = TempData["Publicacion"] as CarrerasViewModel;
            m.IdPublicacion = mAnterior.IdPublicacion;
            Operacion opBD = new Operacion();
           
            string sql = String.Format("UPDATE [dbo].[Publicacion]" +
                            "SET [Descricpion] = '{0}',[Vacante] = '{1}',[Requisitos] = '{2}'" +
                            " WHERE ID = {3}",m.publicacion.Descripcion,m.publicacion.Vacante,m.publicacion.Requisitos,m.IdPublicacion);
            opBD.insertar(sql);

            List<String> listaCarreras = opBD.carreras(m.publicacion.Carreras);
            opBD.insertar("Delete from Categoria where IdPublicacion = "+m.IdPublicacion+" ;");
            foreach (var carr in listaCarreras)
            {
                sql = String.Format("INSERT INTO [dbo].[Categoria] ([IdPublicacion],[Carrera])" +
                   " VALUES({0},'{1}')", m.IdPublicacion, carr);
                opBD.insertar(sql);
            }

            TempData["Usuario"] = u;
            return RedirectToAction("AdminPublicacion");
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }


    }
}