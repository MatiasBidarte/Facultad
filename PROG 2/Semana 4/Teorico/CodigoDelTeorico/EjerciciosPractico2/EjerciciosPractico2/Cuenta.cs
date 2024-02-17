using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPractico2
{
    internal class Cuenta
    {
        private string _titular;
        private int _numero;
        private double _saldo;
        private string _tipo;
        private string _moneda;
        private int _cantidadRetiros;

        public Cuenta(string titular, int numero, string tipo, string moneda)
        {
            _titular = titular;
            _numero = numero;
            _tipo = tipo;
            _moneda = moneda;
            _saldo = 0;
            _cantidadRetiros = 0;
        }

        public bool Depositar(string moneda, double deposito)
        {
            bool exito = false;
            if(moneda == _moneda)
            {
                if((_moneda == "$" && deposito <= 50000) || (_moneda == "U$S" && deposito <= 1000))
                {
                    _saldo += deposito;
                    exito = true;
                }
            }
            return exito;
        }

        public bool Retirar(double retiro)
        {
            bool exito = false;
            double totalARetirar = retiro;

            if(_cantidadRetiros >= 5)
            {
                if (_moneda == "$") totalARetirar += 50;
                if (_moneda == "U$S") totalARetirar += 1;
            }

            if (_saldo >= totalARetirar)
            {
                _saldo -= totalARetirar;
                _cantidadRetiros ++;
                exito = true;
            }
            return exito;
        }

        public override string ToString()
        {
            return $"Nº:{_numero} - Titular: {_titular} - Saldo: {_moneda} {_saldo} - Retiros: {_cantidadRetiros}";
        }
    }
}
