using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DiscosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult ListaDisco()
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            ViewBag.Discos = sistema.Discos;
            return View();
        }

        public IActionResult DetalleDisco(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(codigo)) throw new Exception("Codigo no puede ser vacio");
                Disco d = sistema.ObtenerDiscoPorCodigo(codigo);
                if (d == null) throw new Exception("Disco no encontrado");
                ViewBag.Disco = d;
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListaDisco");
            }

            return View();
        }

        public IActionResult AltaDisco()
        {
            return View(new Disco());
        }

        public IActionResult ProcesarAltaDisco(Disco d, string nombreMusico)
        {
            try
            {
                //Hacer validaciones vacias de datos del disco
                if (string.IsNullOrEmpty(nombreMusico)) throw new Exception("Musico no puede ser vacio");
                Musico m = sistema.ObtenerMusicoPorNombre(nombreMusico);
                if (m == null) throw new Exception("No se encontró musico");
                d.Musico = m;
                sistema.AltaDisco(d);
                ViewBag.Exito = "Disco dado de alta";
                return View("AltaDisco", new Disco());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AltaDisco", d);
            }
        }

        public IActionResult CambiarNombre(string id)
        {
            //Hacer controles de id vacio
            try
            {
                Disco d = sistema.ObtenerDiscoPorCodigo(id);
                if (d == null) throw new Exception("Disco no encontrado");
                ViewBag.Disco = d;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListaDisco");   
            }
        }

        public IActionResult ProcesarCambioNombre(string codigo, string titulo)
        {
            try
            {
                //validaciones de datos nulos
                Disco d = sistema.ObtenerDiscoPorCodigo(codigo);
                if (d == null) throw new Exception("Disco no encontrado");
                sistema.CambiarTituloDisco(d, titulo);
                TempData["Exito"] = $"Se modificó correctamente el disco {d.Codigo}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("ListaDisco");
        }
    }
}
