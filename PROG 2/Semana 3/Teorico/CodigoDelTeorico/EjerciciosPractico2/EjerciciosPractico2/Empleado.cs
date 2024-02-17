using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPractico2
{
    internal class Empleado
    {
        private string _cedula;
        private string _nombre;
        private int _cantJornales;
        private Cargo _cargo;
        private Sexo _sexo;

        public Empleado(string cedula, string nombre, int cantJornales, Cargo cargo, Sexo sexo)
        {
            _cedula = cedula;
            _nombre = nombre;
            _cantJornales = cantJornales;
            _cargo = cargo;
            _sexo = sexo;
        }

        public Cargo Cargo 
        { 
            get { return _cargo; } 
        }

        public override string ToString()
        {
            return $"{_nombre} - {_cargo.Nombre} - {_sexo}";
        }

        public void IncrementarJornales(int jornales)
        {
            _cantJornales += jornales;
        }

        public double CalcularSueldo()
        {
           return _cantJornales * _cargo.ValorJornal;
        }

        public override bool Equals(object? obj)
        {
            Empleado emp = obj as Empleado;
            return emp != null && this._cedula.Equals(emp._cedula);
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre) || _nombre.Length < 2) throw new Exception("El nombre no puede tener menos de 2 caracteres");
        }

        private void ValidarJornal()
        {
            if (_cantJornales < 0) throw new Exception("La cantidad de jornales no puede ser negativo");
        }

        private void ValidarCedula()
        {
            if (string.IsNullOrEmpty(_cedula) || _cedula.Length != 8) throw new Exception("La cedula debe tener 8 caracteres");
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarJornal();
            ValidarCedula();
        }
    }
}
