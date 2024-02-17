using System;
namespace Ejercicio1
{
	public class Cliente
	{
		private string _id;
		private string _nombre;
		private CuentaCorriente _cuentaCorriente;

        public Cliente(string id, string nombre, CuentaCorriente cuentaCorriente)
        {
            _id = id;
            _nombre = nombre;
            _cuentaCorriente = cuentaCorriente;
        }

        private void validarId()
        {
            if (string.IsNullOrEmpty(_id) || _id.Length != 8) throw new Exception("el id tiene q ser mayor a 8 digitos");
        }

        private void validarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception();
        }

        private void ValidarCuenta()
        {
            if (_cuentaCorriente == null) throw new Exception("la cuenta no puede ser null");
        }

        public void Validar()
        {
            validarId();
            validarNombre();
            ValidarCuenta();
        }

        public override string ToString()
        {
            return $"id: {_id} - nombre: {_nombre} - cuenta corriente: {_cuentaCorriente}";
        }

        public void Depositar(double monto, TipoMoneda moneda)
        {
            _cuentaCorriente.Deposito(monto, moneda);
        }

        public void Retirar(double monto, TipoMoneda moneda)
        {
            _cuentaCorriente.Retiro(monto, moneda);
        }

        public double SaldoActual()
        {
            return _cuentaCorriente.SaldoActual;
        }
    }
}

