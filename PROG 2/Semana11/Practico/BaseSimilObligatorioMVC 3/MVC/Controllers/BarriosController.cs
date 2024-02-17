using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class BarriosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult ListarBarrios()
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            ViewBag.Barrios = sistema.Barrios;
            return View();
        }

        public IActionResult ListarBarrio(int? codigo)
        {
            try
            {
                if (codigo == null || codigo < 0) throw new Exception("El codigo no puede ser vacio");
                ViewBag.Barrio = sistema.ObtenerBarrio((int)codigo);
                return View();
            } catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListarBarrios");
            }
        }
    }
}

