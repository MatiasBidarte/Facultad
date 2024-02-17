using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace MVC.Controllers
{
    public class PropiedadesController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult ListarPropiedades()
        {
            ViewBag.Propiedades = sistema.Propiedades;
            return View();
        }

        public IActionResult CasasMayoresA(int? area)
        {
            try
            {

                if (area == null || area < 0) throw new Exception("el area es invalida");
                ViewBag.Casas = sistema.CasasPorMetro((int)area);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}

