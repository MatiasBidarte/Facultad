
namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerTodos <T>
    {
        public IEnumerable<T> Ejecutar();
    }
}
