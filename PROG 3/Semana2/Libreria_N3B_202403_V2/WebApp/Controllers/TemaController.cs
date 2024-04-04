
using LogicaAccesoDatos.Listas;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Tema;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WewApp.Controllers
{
    public class TemaController : Controller
    {
       
        RepositorioTema _repositorioTema = new RepositorioTema();

        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View(_repositorioTema.GetAll());
        }



        public IActionResult Details(int id)
        {
            try
            {
                Tema tema = _repositorioTema.GetById(id) ?? throw new Exception("No se encontro el id");
                VMTema _VMtema = new VMTema()
                {
                    Id = tema.Id,
                    Nombre = tema.Nombre,
                    Descripcion = tema.Descripcion
                };
                return View(_VMtema);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró " + id });
            }
        }


        public IActionResult Delete(int id)
        {
            try
            {
                _repositorioTema.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }

        }




        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Tema tema = _repositorioTema.GetById(id);
            if (tema == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró " + id });
            }
            return View(tema);

        }

        [HttpPost]
        public IActionResult Edit(int id, Tema tema)
        {
            try
            {
                _repositorioTema.Update(id, tema);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Tema tema)
        {
            try
            {
                _repositorioTema.Add(tema);
                return RedirectToAction("Index", new { mensaje = "Se dio de alta el tema en forma exitosa." });
            }
            catch (TemaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Hubo un error al crear el tema.. Intente nuevamente.";
            }

            return View(tema);
        }

    }
}

