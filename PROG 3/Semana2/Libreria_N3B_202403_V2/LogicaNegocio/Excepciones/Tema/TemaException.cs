
namespace LogicaNegocio.Excepciones.Tema
{
    public class TemaException : DomainException
    {
        public TemaException() : base("Error de tema") {}

        public TemaException(string message) : base(message) { }
    }
}
