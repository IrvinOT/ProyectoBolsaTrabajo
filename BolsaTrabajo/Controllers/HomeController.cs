using Biblioteca;
using BolsaTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (TempData.ContainsKey("Usuario"))
            {
                var U = TempData["Usuario"] as UsuarioViewModel;
                TempData["Usuario"] = U;
                Operacion opBd = new Operacion();
                var m = new CarrerasViewModel();
                m.Tipo = U.Tipo;
                return View(m);
            }
            return RedirectToAction("Login", "Cuenta");

        }


        [HttpPost]
        public ActionResult Index(CarrerasViewModel m)
        {
            Operacion opBd = new Operacion();
            m.publicacionDetallada = opBd.leerPublicacionDetallada(m.IdPublicacion);
            var U = TempData["Usuario"] as UsuarioViewModel;
            TempData["Usuario"] = U;
            m.Tipo = U.Tipo;
            TempData["Publicacion"] = m;
            return RedirectToAction("Vacantes");
        }

        [HttpGet]
        public ActionResult Vacantes()
        {
            if (TempData.ContainsKey("Usuario"))
            {
                var U = TempData["Usuario"] as UsuarioViewModel;
                TempData["Usuario"] = U;

                if (TempData.ContainsKey("Publicacion"))
                {
                    var m = TempData["Publicacion"] as CarrerasViewModel;
                    m.Tipo = U.Tipo;
                    return View(m);
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Cuenta");
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
            if (TempData.ContainsKey("Usuario"))
            {
                var U = TempData["Usuario"] as UsuarioViewModel;
                TempData["Usuario"] = U;
                return View();
            }
            return RedirectToAction("Login", "Cuenta");

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
            if (TempData.ContainsKey("Usuario"))
            {
                var U = TempData["Usuario"] as UsuarioViewModel;
                TempData["Usuario"] = U;

                Operacion opBd = new Operacion();
                var modelo = new CarrerasViewModel
                {
                    listPublicaciones = opBd.leerPublicaciones(U.IdUsuario)
                };
                return View(modelo);
            }
            return RedirectToAction("Login", "Cuenta");
        }

        [HttpPost]
        public ActionResult AdminPublicacion(CarrerasViewModel m, string comand)
        {
            if (TempData.ContainsKey("Usuario"))
            {
                Operacion opBd = new Operacion();
                var u = TempData["Usuario"] as UsuarioViewModel;
                TempData["Usuario"] = u;
                m.publicacion = opBd.leerPublicacion(m.IdPublicacion);
                TempData["Publicacion"] = m;

                if (comand.Equals("Eliminar"))
                {
                    int id = m.IdPublicacion;
                    string sql = String.Format("Delete from Publicacion where ID = {0};", id);
                    opBd.insertar(sql);
                    sql = String.Format("Delete from Categoria where IdPublicacion = {0};", id);
                    opBd.insertar(sql);
                    return RedirectToAction("AdminPublicacion");
                }
                else
                {

                    return RedirectToAction("Modificar");
                }
            }
            return RedirectToAction("Login", "Cuenta");
        }


        [HttpGet]
        public ActionResult Modificar()
        {
            if (TempData.ContainsKey("Usuario"))
            {
                var u = TempData["Usuario"] as UsuarioViewModel;
                TempData["Usuario"] = u;
                if (TempData.ContainsKey("Publicacion"))
                {
                    var m = TempData["Publicacion"] as CarrerasViewModel;
                    TempData["Publicacion"] = m;
                    return View(m);
                }
                return View();
            }
            return RedirectToAction("Login", "Cuenta");
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
                            " WHERE ID = {3}", m.publicacion.Descripcion, m.publicacion.Vacante, m.publicacion.Requisitos, m.IdPublicacion);
            opBD.insertar(sql);

            List<String> listaCarreras = opBD.carreras(m.publicacion.Carreras);
            opBD.insertar("Delete from Categoria where IdPublicacion = " + m.IdPublicacion + " ;");
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