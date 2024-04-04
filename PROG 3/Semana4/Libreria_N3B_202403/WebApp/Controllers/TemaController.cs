
using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Tema;
using LogicaNegocio.IntefazServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WewApp.Controllers
{
    public class TemaController : Controller
    {

        IAlta<Tema> _altaTema;
        IEditar<Tema> _editarTema;
        IEliminar<Tema> _eliminarTema;
        IObtener<Tema> _obtenerTema;
        IObtenerTodos<Tema> _obtenerTemas;

        public TemaController(
            IAlta<Tema> altaTema, 
            IEditar<Tema> editarTema,
            IEliminar<Tema> eliminarTema,
            IObtener<Tema> obtenerTema,
            IObtenerTodos<Tema> obtenerTemas   
            )
        {
            _altaTema = altaTema;
            _editarTema = editarTema;
            _eliminarTema = eliminarTema;   
            _obtenerTema = obtenerTema;
            _obtenerTemas = obtenerTemas;
        }

        public IActionResult Index(string mensaje)
        {
            // todo arreglar los mensajes de error y exitos. En caso que falle el update muestra
            // mensaje en verde
            ViewBag.mensaje = mensaje;
            return View(_obtenerTemas.Ejecutar());
        }

        public IActionResult Details(int id)
        {
            try
            {
                Tema tema = _obtenerTema.Ejecutar(id);
                if (tema == null)
                {
                    throw new Exception("No se encontro el id");
                }
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
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Tema tema = _obtenerTema.Ejecutar(id);
            if (tema == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró " + id });
            }
            return View(tema);

        }

        [HttpPost]
        public IActionResult Delete(Tema tema)
        {
            try
            {
                _eliminarTema.Ejecutar(tema.Id);
                return RedirectToAction("Index");
            }
            catch (NotFoundException e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = "No se puedo dar de baja. Intente nuevamente." });
            }

        }


        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Tema tema = _obtenerTema.Ejecutar(id);
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
                _editarTema.Ejecutar(id, tema);
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
                _altaTema.Ejecutar(tema);
                return RedirectToAction("Index", new { mensaje = "Se dio de alta el tema en forma exitosa." });
            }
            catch (NombreTemaInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (DescripcionTemaInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (ArgumentNullRepositorioException e)
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

