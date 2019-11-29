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
                       model.NombreEmp,model.GiroEmp,model.RazonEmp,model.Calle,model.Colonia,model.Cp,model.Ciudad,model.TelefonoD);
           opBD.insertar(sql);

           int idEmpresa =  opBD.LeerEmpresa("Select ID from Empresa");

            sql = String.Format ("INSERT INTO [dbo].[Empleado]([Nombre],[ApellidoP],[ApellidoM],[Dependencia],[Puesto],[Telefono],[Correo],[Password],[Empresa])"+
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8});",
                model.NombreE,model.ApellidoP,model.ApellidoM,model.DependenciaE,model.PuestoE,model.TelefonoE,model.CorreoE,model.PassE,idEmpresa);
            opBD.insertar(sql);

            return RedirectToAction("Index","Home");
        }
    }
}