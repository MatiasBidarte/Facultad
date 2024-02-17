using System;
namespace Ejercicio_4
{
	public class Cuenta
	{
		private string _titular;
		private double _saldoActual;
		private string _tipoDeCuenta;
		private string _moneda;
		private int _numeroDeCuenta;
		private int _cantidadRetiros;

		Random generador = new Random();

		public Cuenta(string titular, string tipoDeCuenta, string moneda)
		{
			_titular = titular;
			_saldoActual = 0;
			_tipoDeCuenta = tipoDeCuenta;
			_moneda = moneda;
			_numeroDeCuenta = generador.Next(0, 9999);
			_cantidadRetiros = 0;
		}

		public bool Deposito(double saldo, string moneda)
		{
			bool resp = false;

			if (moneda == _moneda)
			{
				if ((moneda == "$" && saldo <= 50000) || (moneda == "U$D" && saldo <= 1000))
				{
                    _saldoActual += saldo;
                    resp = true;
                }
			}

			return resp;
		}

		public bool Retiro(double saldo)
		{
            bool resp = false;
			double totalARetirar = saldo;

			if (_cantidadRetiros > 5)
			{
				if (_moneda == "$") totalARetirar += 50;
				if (_moneda == "U$D") totalARetirar += 1;
			}

            if (_saldoActual >= totalARetirar)
            {
				_saldoActual -= totalARetirar;
				resp = true;
				_cantidadRetiros++;
            }

            return resp;
        }

        public override string ToString()
        {
			return $"titular: {_titular}, saldo actual: {_saldoActual}, tipo de cuenta: {_tipoDeCuenta}, moneda: {_moneda}, numero de cuenta: {_numeroDeCuenta} , retiros: {_cantidadRetiros}";
        }
    }
}

