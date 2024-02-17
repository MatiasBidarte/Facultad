using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PropiedadesController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Listado()
        {
            ViewBag.Propiedades = sistema.Propiedades;
            return View();
        }

        public IActionResult ListadoCasas() 
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            ViewBag.Casas = sistema.ListadoCasas();
            return View();
        }

        public IActionResult FiltrarCasas(double? area) 
        {
            try
            {
                if (area == null || area < 0) throw new Exception("Area no puede ser vacia");
                ViewBag.Casas = sistema.CasasMayorArea((double)area);
                return View("ListadoCasas");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListadoCasas");
            }

        }

        public IActionResult AltaCasa()
        {
            return View(new Casa());
        }

        public IActionResult ProcesarAltaCasa(Casa c, int codigoBarrio, string? calle)
        {
            try
            {
                if (string.IsNullOrEmpty(calle)) throw new Exception("La calle no puede ser nula");
                Barrio b = sistema.ObtenerBarrio(codigoBarrio);
                if (b == null) throw new Exception("Barrio no encontrado");
                Direccion nuevaDir = new Direccion(calle, b);
                c.Direccion = nuevaDir;
                sistema.AgregarCasa(c);
                ViewBag.Exito = "Casa dada de alta";
                return View("AltaCasa", new Casa());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AltaCasa", c);
            }
        }
    }
}
