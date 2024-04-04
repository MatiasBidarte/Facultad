
namespace LogicaNegocio.Excepciones.Tema
{
    public class DescripcionTemaInvalidaException : TemaException
    {
        public DescripcionTemaInvalidaException() : base("La descripción no puede ser nula.")
        {

        }
    }
}

