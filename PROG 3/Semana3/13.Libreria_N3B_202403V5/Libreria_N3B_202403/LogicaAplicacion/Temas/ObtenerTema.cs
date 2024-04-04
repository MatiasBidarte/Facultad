using LogicaAccesoDatos.Listas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Temas
{
    public class ObtenerTema: IObtener<Tema>
    {

        IRepositorioTema _repositorioTema;

        public ObtenerTema(IRepositorioTema repositorioTema)
        {
            _repositorioTema = repositorioTema;
        }

        public Tema Ejecutar(int id)
        {
            return _repositorioTema.GetById(id);
        }

    }
}
