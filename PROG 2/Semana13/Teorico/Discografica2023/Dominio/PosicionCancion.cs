using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PosicionCancion : IValidable
    {
        private int _posicion;
        private Cancion _cancion;

        public PosicionCancion(int pos, Cancion cancion)
        {
            this._posicion = pos;
            this._cancion = cancion;
        }

        public Cancion Cancion
        {
            get { return _cancion; }
        }

        public int Posicion
        {
            get { return _posicion; }
        }

        public void Validar()
        {
            ValidarCancion();
            ValidarPosicion();
        }

        private void ValidarCancion()
        {
            if (_cancion == null) throw new Exception("La cancion no puede estar vacia");
        }

        private void ValidarPosicion()
        {
            if (_posicion <= 0) throw new Exception("La posicion debe ser mayor a cero");
        }

        public override string ToString()
        {
            return $"\n -> {_posicion} - {_cancion.Nombre}";
        }
    }
}
