using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Contratado : Empleado
    {
        private int _anios;
        public Contratado(string cedula, string nombre, int cantJornales, Cargo cargo, Sexo sexo, int anios) : base(cedula, nombre, cantJornales, cargo, sexo)
        {
            _anios = anios;
        }

        private void ValidarAnios()
        {
            if (_anios < 0) throw new Exception("No puede tener antigüedad negativa");
        }

        public override void Validar()
        {
            base.Validar();
            ValidarAnios();
        }

        public override double CalcularSueldo()
        {
            double sueldo = base.CalcularSueldo();
            if (_anios > 5) sueldo *= 1.05;
            return sueldo;
        }

        public override double CalcularSueldoFijo()
        {
            return 55500;
        }

        public override string ToString()
        {
            return $"{_nombre} - {_cargo.Nombre} - {_sexo} - Antiguedad: {_anios}";
        }
    }
}
