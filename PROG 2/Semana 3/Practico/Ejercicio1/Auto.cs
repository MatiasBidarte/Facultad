using System;
namespace Practico2
{
	internal class Auto
	{
		private string _marca;
		private string _modelo;
		private int _año;
		private bool _exoneraImpuestos;
		private string _matricula;

		public Auto(string marca, string modelo, int año, bool exoneraImpuestos, string matricula)
		{
			_marca = marca;
			_modelo = modelo;
			_año = año;
			_exoneraImpuestos = exoneraImpuestos;
			_matricula = matricula;
		}

		public decimal CalcularPatente()
		{
			int respuesta = 15000;

			if (_año < 2015)
			{
				if (_exoneraImpuestos) respuesta = 10000;
				else respuesta = 12000;
			}
			return respuesta;
		}

		private bool ValidarMatricula()
		{
			return _matricula.Length == 7;
		}

		public bool Validar()
		{
			return ValidarMatricula();
		}

        public override string ToString()
        {
            return $"El auto tiene: marca {_marca}, modelo {_modelo}, año {_año}, exonera impuestos {_exoneraImpuestos}, matricula {_matricula}";
        }
    }
}

