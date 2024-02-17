using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Disco : IValidable, IComparable<Disco>
    {
        private string _codigo;
        private Musico _musico;
        private string _titulo;
        private int _anio;
        private List<PosicionCancion> _posicionCanciones;

        public Disco(string codigo, Musico musico, string titulo, int anio)
        {
            this._codigo = codigo;
            this._musico = musico;
            this._titulo = titulo;
            this._anio = anio;
            _posicionCanciones = new List<PosicionCancion>();
        }

        public Disco()
        {
            _posicionCanciones = new List<PosicionCancion>();
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public List<PosicionCancion> PosicionCanciones
        {
            get { return _posicionCanciones; }

        }

        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public Musico Musico
        {
            get { return _musico; }
            set { _musico = value; }
        }

        public void Validar()
        {
            ValidarCodigo();
            ValidarMusico();
            ValidarTitulo();
            ValidarAnio();
        }

        private void ValidarCodigo()
        {
            if (string.IsNullOrEmpty(_codigo)) throw new Exception("Codigo no puede ser vacio");
        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(_titulo)) throw new Exception("Titulo no puede ser vacio");
        }

        private void ValidarMusico()
        {
            if (_musico == null) throw new Exception("Musico no puede ser vacio");
        }

        private void ValidarAnio()
        {
            if (_anio < 0) throw new Exception("El año debe ser mayor a 0");
        }

        public override bool Equals(object? obj)
        {
            Disco d = obj as Disco;
            return d != null && this._codigo.Equals(d._codigo);
        }

        public void AgregarCancionADisco(PosicionCancion pc)
        {
            if (pc == null) throw new Exception("La posicion cancion no puede ser nula");
            pc.Validar();
            ValidarQueNoExisteCancionEnDisco(pc.Cancion);
            ValidarQueLaPosicionNoEsteOcupada(pc.Posicion);
            _posicionCanciones.Add(pc);
        }

        private void ValidarQueNoExisteCancionEnDisco(Cancion c)
        {
            if (c == null) throw new Exception("La cancion no puede ser vacia");
            foreach (PosicionCancion pc in _posicionCanciones)
            {
                if (pc.Cancion.Equals(c)) throw new Exception("La cancion ya existe en el disco");
            }
        }

        private void ValidarQueLaPosicionNoEsteOcupada(int pos)
        {
            foreach (PosicionCancion pc in _posicionCanciones)
            {
                if (pc.Posicion.Equals(pos)) throw new Exception("Ya existe una cancion en esa posicion");
            }
        }

        public double DuracionTotal()
        {
            double total = 0;
            foreach(PosicionCancion pc in _posicionCanciones)
            {
                total += pc.Cancion.Duracion;
            }
            return total;
        }

        public override string ToString()
        {
            return $"{_titulo} - {DuracionTotal()} - Precio: ${CalcularPrecio()}";
        }

        public double CalcularPrecio()
        {
            double total = 0;
            foreach (PosicionCancion pc in _posicionCanciones)
            {
                total += pc.Cancion.Precio;
            }

            double descuento = _musico.ObtenerDescuento();
            total = total - total * descuento / 100;
            return total;   
        }

        public int CompareTo(Disco? other)
        {
            return CalcularPrecio().CompareTo(other.CalcularPrecio()) * - 1 ;
        }

        public bool TengoCancion(Cancion c)
        {
            bool tengo = false;
            int i = 0;
            while(!tengo && i < _posicionCanciones.Count)
            {
                if (_posicionCanciones[i].Cancion.Equals(c)) tengo = true;
                i++;
            }

            return tengo;
        }

        public void CambiarTitulo(string tituloNuevo)
        {
            if (string.IsNullOrEmpty(tituloNuevo)) throw new Exception("Titulo vacio");
            this._titulo = tituloNuevo;
        }

    }
}
