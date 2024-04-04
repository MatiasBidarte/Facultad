using Infraestructura.LogicaAccesoDatos.Listas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Temas
{
    public class EliminarTema: IEliminar<Tema>
    {
       
        IRepositorioTema _repositorioTema;

        public EliminarTema(IRepositorioTema repositorioTema)
        {
            _repositorioTema = repositorioTema;
        }


        public void Ejecutar(int id)
        {
            _repositorioTema.Delete(id);
        }

    }
}
