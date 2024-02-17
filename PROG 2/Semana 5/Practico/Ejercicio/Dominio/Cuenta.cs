using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuenta
    {
        private int _numero;
        private int _cantDepositos;
        private Moneda _moneda;
        private double _saldo;
        private static double s_tipoCambio = 38.95;
        private static int s_ultNumero = 1;

        public Cuenta(Moneda moneda)
        {
            _numero = s_ultNumero;
            _moneda = moneda;
            _cantDepositos = 0;
            _saldo = 0;
            s_ultNumero++;
        }

        private void ValidarMoneda()
        {
            if (_moneda != Moneda.UYU && _moneda != Moneda.USD && _moneda != Moneda.EUR) throw new Exception("La moneda no es valida");
        }

        public void Validar()
        {
            ValidarMoneda();
        }

        public void Retiro(double monto, Moneda moneda)
        {
            //Valido inputs
            if (monto < 0) throw new Exception("No se pueden retirar valores negativos");
            if (_moneda != moneda) throw new Exception("La moneda no coincide");
            if (monto > _saldo) throw new Exception("Saldo insuficiente");

            _saldo -= monto;
        }

        public void Deposito(double monto, Moneda moneda)
        {
            if (monto < 0) throw new Exception("No se pueden retirar valores negativos");
            if (_moneda != moneda) throw new Exception("La moneda no coincide");

            double comision = 0;

            if(_cantDepositos >= 3)
            {
                if (_moneda == Moneda.UYU) comision = 100;
                if (_moneda == Moneda.USD) comision = 100 / s_tipoCambio;
            }

            if (_saldo + monto - comision < 0) throw new Exception($"El saldo resultante no será suficiente para cobrar la comision de {_moneda}{comision}");

            _saldo += monto - comision;
            _cantDepositos++;
        }

        public override string ToString()
        {
            return $"Nº {_numero} - Saldo: {_moneda} {_saldo}";
        }
    }
}
