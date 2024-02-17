using System;
namespace Ejercicio2
{
	internal class Empleado
	{
		private string _nombre;
		private string _apellido;
		private string _fechaDeNacimiento;
		private double _valorHora;
		private int _antiguedad;
		private int _horasTrabajadas;

		public Empleado(string nombre, string apellido, string fechaDeNacimiento, double valorHora, int antiguedad, int horasTrabajadas)
		{
			_nombre = nombre;
			_apellido = apellido;
			_fechaDeNacimiento = fechaDeNacimiento;
			_valorHora = valorHora;
			_antiguedad = antiguedad;
			_horasTrabajadas = horasTrabajadas;
		}

		public double CalcularSalario()
		{
			return  _valorHora * _horasTrabajadas;
		}

		public int CalcularLicencia()
		{
			int respuesta = 25;

			if (_antiguedad <= 5) respuesta = 20;
			else if (_antiguedad > 5 && _antiguedad <= 9) respuesta = 21;

			return respuesta;
		}

        public override string ToString()
        {
			return $"nombre: {_nombre} apellido: {_apellido} fecha de nacimiento: {_fechaDeNacimiento} valor por hora: {_valorHora} antiguedad: {_antiguedad} años horas trabajadas: {_horasTrabajadas}";
        }
    }
}

