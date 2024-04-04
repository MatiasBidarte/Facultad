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

        public List<Autor> MiAutores { get; set; }

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

        public void Update(Tema obj)
        {
            obj.Validar();
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;
        }
    }
}
