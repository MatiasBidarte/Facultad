using System;
using Dominio.Interfaces;
using Dominio.Excepciones.Tema;
namespace Dominio.Entidades
{
	public class Tema: IValidable
	{
		public Tema(){}

		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }

        public void Validar()
        {
			ValidarDescripcion();
			ValidarNombre();
        }

		private void ValidarNombre()
		{
			if (string.IsNullOrEmpty(Nombre) || Nombre.Length < 2)
				throw new NombreTemaException("El nombre debe de tener mas de 2 caracteres");
		}

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion)) throw new DescripcionTemaException("La descripcion no puede ser nula");
        }
    }
}

