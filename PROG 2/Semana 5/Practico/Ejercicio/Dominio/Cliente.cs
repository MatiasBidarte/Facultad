using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        private string _cedula;
        private string _nombre;
        private List<Cuenta> _cuentas = new List<Cuenta>();

        public string Cedula
        {
            get { return _cedula; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public Cliente(string cedula, string nombre)
        {
            _cedula = cedula;
            _nombre = nombre;
        }

        private void ValidarCedula()
        {
            if (string.IsNullOrEmpty(_cedula) || _cedula.Length != 8) throw new Exception("La cedula debe tener 8 caracteres");
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
        }

        public void Validar()
        {
            ValidarCedula();
            ValidarNombre();
        }

        /* public void HacerDepositoAMiCuenta(double monto, Moneda moneda)
        {
            _cuenta.Deposito(monto, moneda);
        } */

        /* public void HacerRetiroDeMiCuenta(double monto, Moneda moneda)
        {
            _cuenta.Retiro(monto, moneda);
        } */

        public void AgregarCuenta(Cuenta cuenta)
        {
            if (cuenta == null) throw new Exception("la cuenta a vincular no puede ser null");
            cuenta.Validar();
            _cuentas.Add(cuenta);
        }

        public List<Cuenta> MostrarCuentas()
        {
            return _cuentas;
        }

        public override string ToString()
        {
            string retorno = $"{_nombre} - CI: {_cedula}";
            if (_cuentas.Count == 0)
            {
                retorno += "\nNo tiene cuentas";
            }
            else
            {
                foreach(Cuenta cu in _cuentas)
                {
                    retorno += $"\n--> {cu.ToString()}";
                }
            }
            return retorno;
        }

        public override bool Equals(object? obj)
        {
            Cliente c = obj as Cliente;
            return c != null && this._cedula.Equals(c._cedula);
        }
    }
}
