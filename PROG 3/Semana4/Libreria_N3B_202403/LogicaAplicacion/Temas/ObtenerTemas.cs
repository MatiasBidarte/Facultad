using Infraestructura.LogicaAccesoDatos.Listas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Temas
{
    public class ObtenerTemas: IObtenerTodos<Tema>
    {

        IRepositorioTema _repositorioTema;

        public ObtenerTemas(IRepositorioTema repositorioTema)
        {
            _repositorioTema = repositorioTema;
        }

        public IEnumerable<Tema> Ejecutar()
        {
            return _repositorioTema.GetAll();
        }

    }
}
