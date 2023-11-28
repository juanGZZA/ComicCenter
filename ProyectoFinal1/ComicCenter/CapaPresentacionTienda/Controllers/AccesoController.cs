using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CapaPresentacionTienda.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario objeto)
        {
            objeto.IdRol = 2;
            int resultado;
            string mensaje = string.Empty;

            ViewData["Nombres"] = string.IsNullOrEmpty(objeto.Nombres) ? "" : objeto.Nombres;
            ViewData["Apellidos"] = string.IsNullOrEmpty(objeto.Apellidos) ? "" : objeto.Apellidos;
            ViewData["Correo"] = string.IsNullOrEmpty(objeto.Correo) ? "" : objeto.Correo;
            if(objeto.Contraseña != objeto.ConfirmarContraseña)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            resultado = new CN_Usuarios().Registrar(objeto, out mensaje);

            if (resultado>0)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }

        }

        [HttpPost]
        public ActionResult Index(string correo, string contraseña)
        {
            Usuario oUsuario = null;
            oUsuario = new CN_Usuarios().Listar().Where(item => item.Correo == correo && item.Contraseña == contraseña).FirstOrDefault();

            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no son correctas";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;

                ViewBag.Error = null;
                return RedirectToAction("Index", "Tienda");
            }
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }

    }
}