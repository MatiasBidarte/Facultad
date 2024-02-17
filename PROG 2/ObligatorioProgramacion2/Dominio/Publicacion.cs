using Dominio.Interfaces;
using System;
namespace Dominio
{
    public abstract class Publicacion : IValidable
    {
        private static int s_ultID = 1;
        protected int _id;
        protected string _titulo;
        protected Miembro _creador;
        protected DateTime _fechaCreacion;
        protected string _contenido;
        protected string _texto;
        protected Privacidad _privacidad;
        protected List<Reaccion> _reacciones;

        /*Se pasa la fecha de creacion por el constructor para asi poder hacer mejores pruebas para el punto 4 del obligatorio*/
        public Publicacion(string titulo, DateTime fechaCreacion, Miembro creador, Privacidad privacidad ,string texto, string contenido)
        {
            _id = s_ultID;
            s_ultID++;
            _texto = texto;
            _fechaCreacion = fechaCreacion;
            _creador = creador;
            _privacidad = privacidad;
            _titulo = titulo;
            _contenido = contenido;
            _reacciones = new List<Reaccion>();
        }

        public Publicacion()
        {
            _id = s_ultID;
            s_ultID++;
            _reacciones = new List<Reaccion>();
        }
        public string Contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public Privacidad Privacidad
        {
            get { return _privacidad; }
            set { _privacidad = value;}
        }

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion= value; }
        }

        public List<Reaccion> Reacciones 
        {
            get { return _reacciones; }
            set { _reacciones = value;}
        }

        public Miembro Creador
        {
            get { return _creador; }
            set { _creador = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(_texto) || _texto.Length < 3) throw new Exception("el texto no puede ser vacio ni menor a 3 caracteres");
        }

        private void ValidarContenido()
        {
            if (string.IsNullOrEmpty(_contenido)) throw new Exception("el texto no puede ser vacio");
        }

        private void ValidarTexto()
        {
            if (string.IsNullOrEmpty(_texto)) throw new Exception("el texto no puede ser vacio");
        }

        private void ValidarMiembro()
        {
            if (_creador == null) throw new Exception("el creador no puede ser vacio");
        }

        public virtual void Validar()
        {
            ValidarMiembro();
            ValidarTexto();
            ValidarContenido();
            ValidarTitulo();
        }

        public int CantidadReaccion(TipoReaccion reaccion)
        {
            int contador = 0;
            foreach (Reaccion r in _reacciones)
            {
                if (r.TipoReaccion == reaccion) contador++;
            }
            return contador;
        }

        public virtual int CalcularVA()
        {
            int cantLikes = CantidadReaccion(TipoReaccion.LIKE);
            int cantDislikes = CantidadReaccion(TipoReaccion.DISLIKE);

            return (cantLikes * 5) + (cantDislikes * -2);
        }

        public abstract string Tipo();

        public override bool Equals(object? obj)
        {
            Publicacion p = obj as Publicacion;
            return p != null && this._id.Equals(p._id);
        }
    }
}

