using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Dominio.Excepciones.Tema;

namespace WebApp.Controllers
{
    public class TemaController : Controller
    {
        private static List<Tema> _temas = new List<Tema>();

        public IActionResult Index()
        {
            return View(_temas);
        }

        [HttpGet]
        public IActionResult CrearTema()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearTema(Tema tema)
        {
            try
            {
                if (tema == null)
                {
                    throw new Exception("El auto no puede ser nulo");
                }
                tema.Validar();

                _temas.Add(tema);
                ViewBag.Mensaje = "Se dio de alta el tema";
                return RedirectToAction("Index");

            }
            catch (TemaInvalidoException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (ArgumentException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Hubo un problema del servidor";
            }
            return View(tema);
        }
    }
}

