using Dominio.EntidadesAgregados;
using Dominio.Excepciones.Auto;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
	public class AutoController : Controller
	{

		private static List<Auto> _autos = new List<Auto>();

		public IActionResult Index()
		{
			return View(_autos);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Create(Auto auto)
		{
			try
			{
				if (auto == null)
				{
					throw new Exception("El auto no puede ser nulo");
				}
				auto.Validar();

				_autos.Add(auto);
				ViewBag.Mensaje = "Se dio de alta el auto";
				return RedirectToAction("Index");

			}
			catch(AutoInvalidoException ex)
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
			return View(auto);
		}
	}
}
