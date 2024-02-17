using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class PublicacionesController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult ListaPostsParaAdmin()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
            {
                return View("NoAutorizado");
            }
            ViewBag.Publicaciones = sistema.Publicaciones;
            return View();
        }

        [HttpPost]
        public IActionResult CensurarPost(int id)
        {
            try
            {

                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
                {
                    return View("NoAutorizado");
                }
                sistema.CensurarPost(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaPostsParaAdmin");
        }

        [HttpPost]
        public IActionResult QuitarCensuraPost(int id)
        {
            try
            {

                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
                {
                    return View("NoAutorizado");
                }
                sistema.QuitarCensuraPost(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaPostsParaAdmin");
        }

        public IActionResult ListaPostsParaMiembro()
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
                if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

                string email = HttpContext.Session.GetString("email")!;
                ViewBag.Posts = sistema.ObtenerPostsParaMiembro(email);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult ReaccionarPost(TipoReaccion r, int id)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                sistema.ReaccionarPost(HttpContext.Session.GetString("email")!, r, id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaPostsParaMiembro");
        }

        [HttpPost]
        public IActionResult ReaccionarComentario(TipoReaccion r, int id)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                sistema.ReaccionarComentario(HttpContext.Session.GetString("email")!, r, id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaPostsParaMiembro");
        }

        public IActionResult CrearPost()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
            {
                return View("NoAutorizado");
            }
            return View(new Post());
        }

        [HttpPost]
        public IActionResult ProcesarCrearPost(Post p, Privacidad tipoPrivacidad, IFormFile imagen)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }

                Miembro creador = sistema.ObtenerMiembroPorEmail(HttpContext.Session.GetString("email")!);
                if (creador.EstaBloqueado)
                {
                    return View("NoAutorizado");
                }

                if (string.IsNullOrEmpty(p.Titulo)) throw new Exception("El titulo no puede ser nulo");
                if (string.IsNullOrEmpty(p.Contenido)) throw new Exception("El contenido no puede ser nulo");
                if (string.IsNullOrEmpty(p.Texto)) throw new Exception("El texto no puede ser nulo");

                p.Privacidad = tipoPrivacidad;
                p.Creador = creador;
                p.FechaCreacion = DateTime.Now;
                p.EstaCensurado = false;

                if (imagen == null || imagen.Length == 0) throw new Exception("No se seleccionó imagen");
                string ruta = "wwwroot/Images/";

                string tipo = imagen.ContentType;

                string[] splitArray = imagen.FileName.Split('.');
                string extension = splitArray[splitArray.Length - 1];

                string nuevoNombre = $"{p.Id}.{extension}";

                ruta += nuevoNombre;
                p.Imagen = nuevoNombre;

                sistema.AltaPost(p);

                using var stream = System.IO.File.Create(ruta);
                imagen.CopyTo(stream);

                ViewBag.Exito = "Post creado con exito";
                return View("CrearPost", new Post());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("CrearPost", p);
            }
        }

        [HttpPost]
        public IActionResult CrearComentario(int idPost, Privacidad privacidad, string titulo, string contenido, string texto)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }

                if (string.IsNullOrEmpty(titulo)) throw new Exception("EL titulo no puede ser nulo");
                if (string.IsNullOrEmpty(contenido)) throw new Exception("EL contenido no puede ser nulo");
                if (string.IsNullOrEmpty(texto)) throw new Exception("EL texto no puede ser nulo");

                Miembro creador = sistema.ObtenerMiembroPorEmail(HttpContext.Session.GetString("email")!);
                if (creador.EstaBloqueado)
                {
                    return View("NoAutorizado");
                }

                Comentario c = new Comentario(titulo, DateTime.Now, creador, privacidad, texto, contenido);

                sistema.AltaComentario(c);
                sistema.AgregarComentarioAPost(idPost, c);
                TempData["Exito"] = "Comentario creado con exito";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaPostsParaMiembro");
        }

        public IActionResult PublicacionesPorTextoYVA(int va, string texto)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                if (va < 0) throw new Exception("No se puede ingresar un numero negativo");
                if (string.IsNullOrEmpty(texto)) throw new Exception("El texto no puede ser nulo");
                
                ViewBag.Publicaciones = sistema.PublicacionesPorTextoYVA(texto, va);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public IActionResult listaDePublicacionesParaFiltrar()
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                ViewBag.Publicaciones = sistema.Publicaciones;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("PublicacionesPorTextoYVA");
        }
    }
}

