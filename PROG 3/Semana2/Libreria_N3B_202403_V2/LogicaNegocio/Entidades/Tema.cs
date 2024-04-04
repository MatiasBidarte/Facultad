using LogicaNegocio.Excepciones.Tema;
using LogicaNegocio.IntefacesDominio;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.Entidades
{
    public class Tema : IValidable, IEntity
    {
        public int Id { get; set; }
               
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre) || Nombre.Length <= 2)
            {
                throw new NombreTemaInvalidaException();
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new DescripcionTemaInvalidaException();
            }
        }

        public void Update(Tema tema)
        {
            tema.Validar();
            Nombre = tema.Nombre;
            Descripcion = tema.Descripcion;
        }
    }
}
