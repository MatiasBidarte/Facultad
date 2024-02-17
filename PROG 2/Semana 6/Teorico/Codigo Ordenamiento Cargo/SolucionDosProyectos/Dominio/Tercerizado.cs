using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tercerizado : Empleado
    {
        private DateTime _fecha;

        public Tercerizado(string cedula, string nombre, int cantJornales, Cargo cargo, Sexo sexo, DateTime fecha):base(cedula, nombre, cantJornales, cargo, sexo)
        {
            _fecha = fecha;
        }

        public override double CalcularSueldo()
        {
            double sueldo = base.CalcularSueldo();
            if (_fecha.Year < 2020) sueldo += 1000;
            return sueldo;
        }

        public override double CalcularSueldoFijo()
        {
            return 15500;
        }

        public override string ToString()
        {
            return $"{_nombre} - {_cargo.Nombre} - {_sexo} - Fecha contratacion: {_fecha.ToShortDateString()}";
        }
    }
}
