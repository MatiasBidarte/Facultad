using Infraestructura.LogicaAccesoDatos.Listas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Temas
{
    public class EditarTema: IEditar<Tema>
    {

        IRepositorioTema _repositorioTema;

        public EditarTema(IRepositorioTema repositorioTema)
        {
            _repositorioTema = repositorioTema;
        }

        public void Ejecutar(int id, Tema tema)
        {
            _repositorioTema.Update(id, tema);
        }

    }
}
