using System;
namespace Dominio.Excepciones.Auto
{
	public class PuertasInvalidasException: AutoInvalidoException
	{
		public PuertasInvalidasException() { }
		public PuertasInvalidasException(string message) : base(message) {}
	}
}

