using System;
namespace Dominio.Excepciones.Tema
{
	public class DescripcionTemaException: TemaInvalidoException
	{
		public DescripcionTemaException(string mensaje): base(mensaje)
		{
		}
	}
}

