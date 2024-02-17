using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Cancion : IValidable
    {
        private static int s_ultId = 1;
        private int _id;
        private string _nombre;
        private double _duracion;
        private double _precio;

        public Cancion(string nombre, double duracion, double precio)
        {
            this._nombre = nombre;
            this._duracion = duracion;
            this._precio = precio;
            this._id = s_ultId;
            s_ultId++;
        }

        public int Id
        {
            get { return _id; }
        }

        public double Duracion
        {
            get { return _duracion; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public double Precio
        {
            get { return _precio; }
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarDuracion();
            ValidarPrecio();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
        }

        private void ValidarDuracion()
        {
            if (_duracion <= 0) throw new Exception("La duracion debe ser mayor a 0");
        }

        private void ValidarPrecio()
        {
            if (_precio < 0) throw new Exception("La precio debe ser mayor o igual a 0");
        }

        public override bool Equals(object? obj)
        {
            Cancion c = obj as Cancion;
            return c != null && this._nombre.Equals(c._nombre);
        }
    }
}
