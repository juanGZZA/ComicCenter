using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;
using System.Web.Security;
namespace CapaPresentacionAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string contraseña)
        {

            Usuario oUsuario = new Usuario();
            oUsuario = new CN_Usuarios().Listar().Where(u => u.Correo == correo && u.Contraseña == contraseña && u.IdRol==1).FirstOrDefault();

            if(oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrecta";
            }
            else
            {

                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }

    }
}