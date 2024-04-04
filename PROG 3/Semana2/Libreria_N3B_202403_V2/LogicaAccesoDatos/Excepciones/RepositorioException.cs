
namespace LogicaAccesoDatos.Excepciones
{
	public class RepositorioException: Exception
	{
		public RepositorioException() : base("No se recibio la informacion correcta") {}

		public RepositorioException(string message) : base(message) {}
	}
}

