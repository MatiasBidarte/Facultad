using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Register()
        {
            return View(new Miembro());
        }

        [HttpPost]
        public IActionResult ProcesarRegister(Miembro m)
        {
            try
            {
                if (string.IsNullOrEmpty(m.Email)) throw new Exception("El mail no puede ser nulo");
                if (string.IsNullOrEmpty(m.Contrasenia)) throw new Exception("La contraseña no puede ser nula");
                if (string.IsNullOrEmpty(m.Nombre)) throw new Exception("El nombre no puede ser nulo");
                if (string.IsNullOrEmpty(m.Apellido)) throw new Exception("El apellido no puede ser nulo");

                sistema.AltaUsuario(m);

                HttpContext.Session.SetString("email", m.Email);
                HttpContext.Session.SetString("rol", m.Tipo());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Register", m);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ProcesarLogin(string email, string contrasenia)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new Exception("email nulo, revise");
                if (string.IsNullOrEmpty(contrasenia)) throw new Exception("contraseña nula, revise");

                Usuario u = sistema.Login(email, contrasenia);
                if (u == null) throw new Exception("email o contraseña incorrectos");

                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("rol", u.Tipo());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Login");
            }
        }

        public IActionResult ListaMiembros()
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];

            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Miembro")
            {
                return View("NoAutorizado");
            }

            ViewBag.Miembros = sistema.ObtenerMiembrosOrdenados();
            return View();
        }

        [HttpPost]
        public IActionResult BloquearMiembro(string email)
        {
            try
            {

                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
                {
                    return View("NoAutorizado");
                }
                sistema.BloquearMiembro(email);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaMiembros");
        }

        [HttpPost]
        public IActionResult DesbloquearMiembro(string email)
        {
            try
            {

                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
                {
                    return View("NoAutorizado");
                }
                sistema.DesbloquearMiembro(email);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaMiembros");
        }

        public IActionResult VerMiembros()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
            {
                return View("NoAutorizado");
            }

            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

            ViewBag.Miembros = sistema.ObtenerMiembrosOrdenados();
            return View();
        }

        public IActionResult CambioDeContrasenia ()
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
            {
                return View("NoAutorizado");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarCambioDeContrasenia(string contNueva)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                if (string.IsNullOrEmpty(contNueva)) throw new Exception("La nueva contraseña no puede ser vacia");
                if (contNueva.Length < 8) throw new Exception("La contraseña no puede tener longitud menor a 8");

                Miembro miUsr = sistema.ObtenerMiembroPorEmail(HttpContext.Session.GetString("email")!);

                sistema.CambiarContrasenia(miUsr, contNueva);
                TempData["Exito"]= "Contraseña cambiada con exito";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("CambioDeContrasenia");
        }
    }
}

