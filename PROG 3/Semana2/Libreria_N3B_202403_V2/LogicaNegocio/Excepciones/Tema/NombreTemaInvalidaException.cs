
namespace LogicaNegocio.Excepciones.Tema
{
    public class NombreTemaInvalidaException : TemaException
    {
        public NombreTemaInvalidaException() : base("El nombre no puede ser nulo y debe tener mas de 2 letras.")
        {

        }

    }
}
