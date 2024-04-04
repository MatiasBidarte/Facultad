using System;
namespace Dominio.Excepciones.Tema
{
	public class NombreTemaException: TemaInvalidoException
	{
		public NombreTemaException(string mensaje): base(mensaje)
		{
		}
	}
}

