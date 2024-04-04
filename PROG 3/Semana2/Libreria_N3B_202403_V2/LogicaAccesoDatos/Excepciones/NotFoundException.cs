namespace LogicaAccesoDatos.Excepciones
{
    public class NotFoundException : RepositorioException
    {
        public NotFoundException(string message) : base(message) { }
    }
}

