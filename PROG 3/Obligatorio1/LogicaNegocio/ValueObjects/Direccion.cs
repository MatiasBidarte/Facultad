using System;
namespace LogicaNegocio.ValueObjects
{
	public record Direccion
	{
		public string Calle { get; }
		public int Numero { get; }
		public string Ciudad { get; }
		public int DistanciaDepositoPapeleria { get; }

		public Direccion (string calle, int numero, string ciudad, int distanciaDepositoPapeleria)
		{
			Calle = calle;
			Numero = numero;
			Ciudad = ciudad;
			DistanciaDepositoPapeleria = distanciaDepositoPapeleria;
		}
	}
}

