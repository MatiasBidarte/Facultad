using System;
namespace Dominio.Excepciones.Tema
{
	public abstract class TemaInvalidoException: Exception
	{
		public TemaInvalidoException(string mensaje): base(mensaje){}
	}
}

