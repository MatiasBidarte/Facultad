
namespace LogicaNegocio.IntefazServicios
{
    public interface IEditar <T>
    {
        public void Ejecutar(int id, T obj);
    }
}
