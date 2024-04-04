
namespace Infraestructura.LogicaAccesoDatos.Excepciones
{
    public class ArgumentNullRepositorioException : RepositorioException
    {
        public ArgumentNullRepositorioException(): base("No se recibio informaciòn vàlida.") { }

    }
}
