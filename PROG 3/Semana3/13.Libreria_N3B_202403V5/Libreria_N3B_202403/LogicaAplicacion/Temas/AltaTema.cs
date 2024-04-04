using LogicaAccesoDatos.Listas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Temas
{
    public class AltaTema: IAlta<Tema>
    {
        IRepositorioTema _repositorioTema;

        public AltaTema(IRepositorioTema repositorioTema)
        {
            _repositorioTema = repositorioTema;
        }

        public void Ejecutar(Tema tema)
        {
            _repositorioTema.Add(tema);
        }

    }
}
