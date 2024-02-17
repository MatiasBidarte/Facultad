using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cargo : IValidable, IComparable<Cargo>
    {
        private static int s_ultCodigo = 1;
        private string _nombre;
        private int _codigo;
        private double _valorJornal;

        public Cargo(string nombre, double valorJornal)
        {
            _nombre = nombre;
            _codigo = s_ultCodigo;
            s_ultCodigo++;
            _valorJornal = valorJornal;
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public double ValorJornal
        {
            get { return _valorJornal; }
            set { _valorJornal = value; }
        }

        public override string ToString()
        {
            return $"{_nombre} - Jornal: {_valorJornal}";
        }

        public void CambiarValorJornal(double valorNuevo)
        {
            _valorJornal = valorNuevo;
        }

        public override bool Equals(object? obj)
        {
            Cargo c = obj as Cargo;
            return c != null && this._codigo.Equals(c._codigo);
        }

        private void ValidarJornal()
        {
            if (_valorJornal < 0) throw new Exception("El jornal no puede ser negativo");
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre) || _nombre.Length < 2) throw new Exception("El nombre no puede tener menos de 2 caracteres");
        }

        
        public void Validar()
        {
            ValidarJornal();
            ValidarNombre();
        }

        public int CompareTo(Cargo? other)
        {
            //Orden ASC
            //return _nombre.CompareTo(other._nombre);

            //Orden DESC 1
            //return other._nombre.CompareTo(_nombre);

            //Orden DESC 2
            //return _nombre.CompareTo(other._nombre) * -1;

            int comparacion = _nombre.CompareTo(other._nombre);
            if (comparacion == 0) comparacion = _valorJornal.CompareTo(other._valorJornal);
            return comparacion;
        }
    }
}
