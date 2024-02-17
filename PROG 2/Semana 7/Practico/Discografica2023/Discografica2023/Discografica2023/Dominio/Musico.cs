using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public abstract class Musico : IValidable
    {
        protected string _nombre;
        protected string _pais;

        public Musico(string nombre, string pais)
        {
            this._nombre = nombre;
            this._pais = pais;
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarPais();
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public string Pais
        {
            get { return _pais; }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede estar vacio");
        }

        private void ValidarPais()
        {
            if (string.IsNullOrEmpty(_pais)) throw new Exception("El pais no puede estar vacio");
        }

        public abstract double DevolverDescuento();

        public override string ToString()
        {
            return $"Nombre: {_nombre} - Pais: {_pais}";
        }

        public override bool Equals(object? obj)
        {
            Musico m = obj as Musico;
            return m != null && this._nombre.Equals(m._nombre); 
        }
    }
}
