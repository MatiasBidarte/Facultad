using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BarriosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Listado()
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            ViewBag.Barrios = sistema.Barrios;
            return View();
        }

        public IActionResult DetalleBarrio(int? id)
        {
            try
            {
                if (id == null || id < 0) throw new Exception("El codigo es vacio");
                ViewBag.Barrio = sistema.ObtenerBarrio((int)id);
                return View();

            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Listado");
            }
           
        }

        public IActionResult AltaBarrio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarAltaBarrio(int? codigo, string? nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede ser nulo");
                if (codigo < 0) throw new Exception("El codigo no puede ser negativo");
                Barrio b = new Barrio((int)codigo, nombre);
                sistema.AgregarBarrio(b);
                ViewBag.Exito = "Barrio dado de alta correctamente";
            } catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Codigo = codigo;
                ViewBag.Nombre = nombre;
            }
            return View("AltaBarrio");
        }

        public IActionResult ModificarNombre(int codigo)
        {
            try
            {
                if (codigo < 0) throw new Exception("No se puede modificar un barrio con codigo negativo");
                Barrio b = sistema.ObtenerBarrio(codigo);
                if (b == null) throw new Exception("No se encontro el barrio");
                ViewBag.Barrio = b;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Listado");
            }
        }

        public IActionResult ProcesarModificarNombre (int codigo, string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("No se puede ingresar un nombre nulo");
                Barrio b = sistema.ObtenerBarrio(codigo);
                if (b == null) throw new Exception("Barrio no encontrado");
                sistema.CambiarNombreDeBarrio(b, nombre);
                TempData["Exito"] = $"Se modificó correctamente el barrio {b.Codigo}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Listado");
        }
    }
}
