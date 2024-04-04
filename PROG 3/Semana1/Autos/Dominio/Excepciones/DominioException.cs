using System;
namespace Dominio.Excepciones
{
	public abstract class DominioException: Exception
	{
		public DominioException(){}

		public DominioException(string message): base(message) { }
	}
}

