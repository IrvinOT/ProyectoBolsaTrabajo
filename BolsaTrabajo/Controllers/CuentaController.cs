using Biblioteca;
using BolsaTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajo.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UsuarioViewModel model)
        {
            Operacion opBD = new Operacion();
            List<string> lista = opBD.leerUsuario(model.Email ,model.Password);
            if (lista.Count > 0)
            {
                model.IdUsuario = int.Parse(lista.ElementAt(0));
                model.Email = lista.ElementAt(1);
                model.Password = lista.ElementAt(2);
                model.Tipo = lista.ElementAt(3);
                TempData["Usuario"] = model;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Register(EmpresaViewModel model)
        {
            Operacion opBD = new Operacion();
            string sql = String.Format("INSERT INTO [dbo].[Empresa]([Nombre],[Giro],[Descripcion],[Calle],[Colonia],[Cp],[Ciudad],[Telefono])" +
                       " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'); ",
                       model.NombreEmp, model.GiroEmp, model.RazonEmp, model.Calle, model.Colonia, model.Cp, model.Ciudad, model.TelefonoE);
            opBD.insertar(sql);


            sql = String.Format("INSERT INTO [dbo].[Usuarios] ([Nombre],[ApellidoP],[ApellidoM],[Correo],[Password])" +
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}');",
                model.NombreE, model.ApellidoP, model.ApellidoM, model.CorreoE, model.PassE);
            opBD.insertar(sql);

            sql = String.Format("Select IdUsuario from Usuarios where Correo = '{0}';", model.CorreoE);
            int idEmpleado = opBD.LeerEntero(sql);
            int idEmpresa = opBD.LeerEntero("Select ID from Empresa where Nombre = '" + model.NombreEmp + "';");
            sql = String.Format("INSERT INTO [dbo].[Empleado] ([IdUsuario],[Dependencia],[Puesto],[Telefono],[Empresa])" +
                                " VALUES({0},'{1}','{2}','{3}',{4});", idEmpleado, model.DependenciaE, model.PuestoE, model.TelefonoD, idEmpresa);
            opBD.insertar(sql);

            return RedirectToAction("Index", "Home");
        }
    }
}