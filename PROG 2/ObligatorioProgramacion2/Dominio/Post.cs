using System;
using System.Security.Cryptography;

namespace Dominio
{
    public class Post : Publicacion, IComparable<Post>
    {
        private string _imagen;
        private List<Comentario> _comentarios;
        private bool _estaCensurado;
        private bool _textoMenorA50; /*Propiedad hecha para el punto 4 del obligatorio*/

        public Post(string titulo, DateTime fechaCreacion, Miembro creador,string imagen, Privacidad privacidad , bool estaCensurado, string texto, string contenido) : base(titulo, fechaCreacion, creador, privacidad ,texto, contenido)
        {
            _imagen = imagen;
            _estaCensurado = estaCensurado;
            _comentarios = new List<Comentario>();
            _textoMenorA50 = false;
        }

        public Post()
        {
            _comentarios = new List<Comentario>();
            _textoMenorA50 = false;
        }
        public string Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        public bool TextoMenorA50
        {
            get { return _textoMenorA50; }
        }

        public List<Comentario> Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }

        public bool EstaCensurado
        {
            get { return _estaCensurado; }
            set { _estaCensurado = value; }
        }

        private void ValidarImagen() /*Valida si la extension es jpg o png o jpeg*/
        {
            if (string.IsNullOrEmpty(_imagen)) throw new Exception("La imagen no puede ser nula");
            string[] words = _imagen.Split('.');
            if (words.Length != 2) throw new Exception("El nombre del archivo es erroneo");
            if (words[1] != "jpg" && words[1] != "png" && words[1] != "jpeg") throw new Exception("La extension de la imagen es invalida");
        }

        public override void Validar()
        {
            base.Validar();
            ValidarImagen();
        }

        public void AgregarComentario(Comentario c)
        {
            _comentarios.Add(c);
        }

        /*Metodo hecho para el punto 4, asi poder devolver solo los primeros 50 caracteres de la propiedad texto*/
        private string RetornarTexto()
        {
            if (_textoMenorA50)
            {
                if (_texto.Length > 50)
                {
                    string textoCorto = _texto.Substring(0, 50);
                    return textoCorto;
                }
                else return _texto;
            }
            else return _texto;
        }

        /*Metodo usado solo en el punto 4 para indicar que el texto tiene que acortarse a 50 caracteres*/
        public void ModificarLongitudDeTexto()
        {
            _textoMenorA50 = !_textoMenorA50;
        }

        public override string ToString()
        {
            return $"Tipo: Post - Id: {_id} - Fecha de cracion: {_fechaCreacion} - Titulo: {_titulo} - Texto: {RetornarTexto()}";
        }

        public void Censurar()
        {
            _estaCensurado = true;
        }

        public void QuitarCensura()
        {
            _estaCensurado = false;
        }

        public override int CalcularVA()
        {
            return _privacidad == Privacidad.Publico ? base.CalcularVA() + 10 : base.CalcularVA();
        }

        public override string Tipo()
        {
            return "Post";
        }

        /*Metodo CompareTo hecho para que se compare por titulo*/
        public int CompareTo(Post? other)
        {
            return _titulo.CompareTo(other._titulo) * -1;
        }
    }
}