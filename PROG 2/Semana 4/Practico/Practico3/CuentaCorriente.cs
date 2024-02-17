using System;
namespace Ejercicio1
{
	public class CuentaCorriente
	{
		private int _numeroCuenta;
		private TipoMoneda _tipoMoneda;
		private double _saldoActual;
        private int _contador;
        private static double s_tipoCambioUSD = 38;
        private static double s_comisionUYU = 100;

        public double SaldoActual
        {
            get { return _saldoActual; }
        }

        public CuentaCorriente(int numeroCuenta, TipoMoneda tipoMoneda)
        {
            _numeroCuenta = numeroCuenta;
            _tipoMoneda = tipoMoneda;
            _saldoActual = 0;
            _contador = 0;
        }

        private void ValidarMoneda()
        {
            if (_tipoMoneda != TipoMoneda.USD && _tipoMoneda != TipoMoneda.UYU) throw new Exception("la moneda solo puede ser en USD o UYU");
        }

        private void validarNumCuenta()
        {
            if (_numeroCuenta <= 0) throw new Exception();
        }

        private void validarSaldoActual()
        {
            if (_saldoActual < 0) throw new Exception();
        }

        public void Validar()
        {
            validarNumCuenta();
            validarSaldoActual();
            ValidarMoneda();
        }

        public void Deposito(double monto, TipoMoneda moneda)
        {
            if (monto < 0) throw new Exception("No se puede retirar saldo negativo");
            if (moneda != _tipoMoneda) throw new Exception("El tipo de moneda no es la correcta");

            double comision = 0;

            if (_contador > 3)
            {
                if (_tipoMoneda == TipoMoneda.UYU) comision = s_comisionUYU;
                if (_tipoMoneda == TipoMoneda.USD) comision = s_comisionUYU / s_tipoCambioUSD;
            }

            if (_saldoActual + monto - comision < 0) throw new Exception("Saldo insuficiente para cobrar comision");
                
            _saldoActual += monto;
            _contador++;
        }

        public void Retiro(double monto, TipoMoneda moneda)
        {
            if (monto < 0 ) throw new Exception("No se puede retirar saldo negativo");
            if (moneda != _tipoMoneda) throw new Exception("El tipo de moneda no es la correcta");
            if (_saldoActual < monto) throw new Exception("No se puede retirar mas saldo del disponible");

            _saldoActual -= monto;
        }

        public override string ToString()
        {
            return $"numero de cuenta: {_numeroCuenta} - tipo de moneda: {_tipoMoneda} - saldo actual: {_saldoActual}";
        }
    }
}

