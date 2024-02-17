using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PosCancion
    {
        private Cancion _cancion;
        private int _pos;

        public PosCancion(Cancion cancion, int pos)
        {
            _cancion = cancion;
            _pos = pos;
        }

        public int DuracionCancion()
        {
            return _cancion.Duracion;
        }

        public int ValorCancion()
        {
            return _cancion.Precio;
        }

        private void ValidarPosicion()
        {
            if (_pos <= 0) throw new Exception("La posicion ingresada no es valida");
        }

        private void ValidarCancion()
        {
            _cancion.Validar();
        }

        public void Validar()
        {
            ValidarPosicion();
            ValidarCancion();
        }

        public override string ToString()
        {
            return $"cancion: {_cancion} - posicion: {_pos}";
        }
    }
}
