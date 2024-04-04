namespace LogicaAccesoDatos.Excepciones
{
    public class ArgumentNullRepositorioException : RepositorioException
    {
        public ArgumentNullRepositorioException(string message) : base(message) { }
    }
}

