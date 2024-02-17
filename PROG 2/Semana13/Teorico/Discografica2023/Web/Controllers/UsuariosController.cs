using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarLogin(string email, string pass)
        {
            try
            {
                if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass)) 
                {
                    throw new Exception("Datos vacios");
                }

                Usuario u = sistema.Login(email, pass);
                if (u == null) throw new Exception("Email o contraseña incorrectos");
                
                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("rol", u.Tipo());

                //HttpContext.Session.SetInt32("unNumero", 123);
                
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Login");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Perfil()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View("NoAutorizado");
            }

            Usuario u = sistema.ObtenerUsuarioPorMail(HttpContext.Session.GetString("email"));
            if (u == null) return View("NoAutorizado");
            ViewBag.Usuario = u;
            return View();
        }

        [HttpPost]
        public IActionResult HacerFavorito(string nombre)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Fan")
            {
                return View("NoAutorizado");
            }

            //Controles de vacios de los parametros
            Musico m = sistema.ObtenerMusicoPorNombre(nombre);
            Usuario u = sistema.ObtenerUsuarioPorMail(HttpContext.Session.GetString("email"));

            sistema.HacerFavorito(u, m);
            return RedirectToAction("ListaMusicos", "Musicos");
        }
    }
}
