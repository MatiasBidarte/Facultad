using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

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

        [HttpGet]
        public IActionResult AltaDisco()
        {
            return View(new Disco());
        }

        [HttpPost]
        public IActionResult ProcesarAltaDisco(Disco d, string nombreMusico, IFormFile archivo)
        {
            try
            {
                //Hacer validaciones vacias de datos del disco
                if (string.IsNullOrEmpty(nombreMusico)) throw new Exception("Musico no puede ser vacio");
                Musico m = sistema.ObtenerMusicoPorNombre(nombreMusico);
                if (m == null) throw new Exception("No se encontró musico");
                d.Musico = m;

                //LOGICA Para agregar la imagen
                if (archivo == null || archivo.Length == 0) throw new Exception("No se seleccionó archivo");
                string ruta = "wwwroot/images/";

                //Con esto pueden ver el tipo de file
                string tipo = archivo.ContentType;

                string[] splitArray = archivo.FileName.Split('.');
                string extension = splitArray[splitArray.Length - 1];

                string nuevoNombre = $"{d.Codigo}.{extension}";

                //EN ESTE PUNTO TODAVIA NO SUBO EL ARCHIVO, PREPARO LA RUTA Y AGREGO EL NOMBRE DE LA IMAGEN A MI DISCO PARA QUE LO VALIDE
                ruta += nuevoNombre;
                d.Imagen = nuevoNombre;


                sistema.AltaDisco(d);

                // Creamos el stream que nos permite escribir archivos a la ruta dada (incluido el nombre del archivo)
                using var stream = System.IO.File.Create(ruta);
                // Subimos el archivo a la carpeta
                archivo.CopyTo(stream);

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

        [HttpPost]
        public IActionResult DarLike(string codigo)
        {
            Disco d = sistema.ObtenerDiscoPorCodigo(codigo);
            sistema.DarLike(d);
            return RedirectToAction("ListaDisco");
        }
    }
}
