using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Disco
    {
        private int _codigo;
        private Autor _autor;
        private string _titulo;
        private int _anio;
        private List<PosCancion> _canciones = new List<PosCancion>();
        private int _duracion;

        public List<PosCancion> Canciones
        {
            get { return _canciones; }
        }

        public int Duracion
        {
            get { return _duracion;}
        }

        public Disco(Autor autor, string titulo, int anio, List<PosCancion> canciones, int codigo)
        {
            _autor = autor;
            _titulo = titulo;
            _anio = anio;
            _canciones = canciones;
            _codigo = codigo;
            _duracion = DuracionDisco();
        }

        private int DuracionDisco()
        {
            int total = 0;
            foreach(PosCancion c in _canciones)
            {
                total += c.DuracionCancion();
            }
            return total;
        }

        public int ValorDisco()
        {
            int valorCanciones = 0;
            foreach(PosCancion c in _canciones)
            {
                valorCanciones += c.ValorCancion();
            }
            return valorCanciones - _autor.DevolverDescuento();
        }

        public void AgregarCancionADisco(PosCancion c)
        {
            if (c == null) throw new Exception("La cancion no puede ser null");
            c.Validar();
            //ValidarQueNoExisteCancionEnDisco
            //ValidarQueLaPosicionNoEsteOcupada
            _canciones.Add(c);
            _duracion = DuracionDisco();
        }

        private void ValidarAutor()
        {
            if (_autor == null) throw new Exception("El autor no puede ser vacio");
            _autor.Validar();
        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(_titulo)) throw new Exception("El titulo no puede ser vacio");
        }

        private void ValidarAnio()
        {
            if (_anio <= 0) throw new Exception("El año no puede ser 0");
        }

        private void ValidarCanciones()
        {
            if (_canciones.Count == 0) throw new Exception("Tiene que haber por lo menos una cancion a agregar");
        }

        public void Validar()
        {
            ValidarAnio();
            ValidarAutor();
            ValidarTitulo();
            ValidarCanciones();
        }

        public override string ToString()
        {
            string retorno = $"titulo: {_titulo}\nautor: {_autor}\nduracion: {_duracion}\ncanciones: ";
            if (_canciones.Count == 0) retorno += "\n No tiene canciones";
            else
            {
                foreach(PosCancion c in  _canciones)
                {
                    retorno += $"\n --> {c}";
                }
            }
            return retorno;
        }
    }
}
