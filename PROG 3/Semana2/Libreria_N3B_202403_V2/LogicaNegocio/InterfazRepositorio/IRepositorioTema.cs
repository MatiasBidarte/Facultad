using LogicaNegocio.Entidades;
namespace LogicaNegocio.InterfazRepositorio
{
	public interface IRepositorioTema: IRepositorio<Tema>
	{
		public IEnumerable<Tema> GetByName(string name);
	}
}

