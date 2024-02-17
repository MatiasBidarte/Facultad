using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cancion
    {
        private int _id;
        private static int s_codigo = 1;
        private int _duracion;
        private int _precio;
        private string _nombre;

        public int Precio
        {
            get { return _precio; }
        }

        public Cancion(int duracion, int precio, string nombre)
        {
            _duracion = duracion;
            _precio = precio;
            _nombre = nombre;
            _id = s_codigo;
            s_codigo++;
        }

        public string Nombre { get { return _nombre; } }

        public int Duracion { get { return _duracion; } }

        private void ValidarDuracion()
        {
            if (_duracion < 0) throw new Exception("La duracion de la cancion no puede ser negativa");
        }

        private void ValidarNombre()
        {
            if (_nombre == null) throw new Exception("El nombre de la cancion no puede ser null");
        }

        private void ValidarPrecio()
        {
            if (_precio == 0) throw new Exception("el precio no puede ser 0");
        }

        public void Validar()
        {
            ValidarDuracion();
            ValidarNombre();
            ValidarPrecio();
        }

        public override bool Equals(object? obj)
        {
            Cancion cancion = obj as Cancion;
            return cancion != null && this._nombre.Equals(cancion._nombre);
        }

        public override string ToString()
        {
            return $"nombre: {_nombre} - precio: {_precio} - duracion: {_duracion}";
        }
    }
}
