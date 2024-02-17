using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Autor
    {
        protected string _nombre;
        protected string _pais;

        public Autor(string nombre, string pais)
        {
            _nombre = nombre;
            _pais = pais;
        }

        public string Nombre { get { return _nombre; } }

        public string Pais { get { return _pais; } }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser nulo");
        }

        private void ValidarPais()
        {
            if (string.IsNullOrEmpty(_pais)) throw new Exception("El pais no puede ser nulo");
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarPais();
        }

        public abstract int DevolverDescuento();

        public override bool Equals(object? obj)
        {
            Autor aut = obj as Autor;
            return aut != null && this._nombre.Equals(aut._nombre);
        }
    }
}
