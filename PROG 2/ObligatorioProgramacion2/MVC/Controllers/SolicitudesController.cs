using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;


namespace MVC.Controllers
{
    public class SolicitudesController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        [HttpPost]
        public IActionResult CrearSolicitud(string email)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                Miembro solicitante = sistema.ObtenerMiembroPorEmail(HttpContext.Session.GetString("email")!);
                Miembro solicitado = sistema.ObtenerMiembroPorEmail(email);

                sistema.SolicitarAmistad(solicitante, solicitado);
                TempData["Exito"] = "Solicitud enviada con exito";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("VerMiembros", "Usuarios");
        }

        public IActionResult ListaSolicitudes()
        {
            try
            {
                if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
                if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }
                ViewBag.Solicitudes = sistema.ObtenerInvitacionesPorEmail(HttpContext.Session.GetString("email")!);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult AceptarSolicitud(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }

                sistema.AceptarInvitacion(id, HttpContext.Session.GetString("email")!);
                TempData["Exito"] = "Solicitud aceptada!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaSolicitudes");
        }

        [HttpPost]
        public IActionResult RechazarSolicitud(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Miembro")
                {
                    return View("NoAutorizado");
                }

                sistema.RechazarInvitacion(id, HttpContext.Session.GetString("email")!);
                TempData["Exito"] = "Solicitud rechazada!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("ListaSolicitudes");
        }
    }
}

