using System;
namespace Dominio.Excepciones.Auto
{
	public abstract class AutoInvalidoException: DominioException
	{
		public AutoInvalidoException(){}

		public AutoInvalidoException(string message): base(message) {}
	}
}

