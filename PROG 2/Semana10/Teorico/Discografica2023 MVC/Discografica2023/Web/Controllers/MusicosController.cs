using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MusicosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult ListaMusicos()
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];

            ViewBag.Musicos = sistema.Musicos;
            return View();
        }

        public IActionResult FiltrarMusicos(string pais)
        {
            try
            {
                if (string.IsNullOrEmpty(pais)) throw new Exception("El pais no puede ser vacio");
                ViewBag.Musicos = sistema.MusicosPorPais(pais);
                return View("ListaMusicos");
            }
            catch(Exception ex) 
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListaMusicos");
            }
            
        }

        [HttpGet]
        public IActionResult AltaSolista()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ProcesarAltaSolista(string? nombre, string? pais, double descuento, Sexo sexo)
        {
            try
            {
                if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(pais) || descuento == null)
                {
                    throw new Exception("Valores nulos, revise la info");
                }

                Solista s = new Solista(nombre, pais, sexo, descuento);
                sistema.AltaMusico(s);
                ViewBag.Exito = "Solista dado de alta correctamente";
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Nombre = nombre;
                ViewBag.Pais = pais;
                ViewBag.Descuento = descuento;
            }

            return View("AltaSolista");
        }

        [HttpGet]
        public IActionResult AltaBanda()
        {
            return View(new Banda());
        }

        [HttpPost]
        public IActionResult ProcesarAltaBanda(Banda b)
        {
            try
            {
                if (string.IsNullOrEmpty(b.Nombre) || string.IsNullOrEmpty(b.Pais) || b.CantIntegrantes == null)
                {
                    throw new Exception("Valores nulos, revise la info");
                }

                sistema.AltaMusico(b);
                ViewBag.Exito = "Banda dada de alta correctamente";
                return View("AltaBanda", new Banda());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AltaBanda", b);
            }
            
        }


    }
}
