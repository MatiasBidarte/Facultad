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
    }
}
