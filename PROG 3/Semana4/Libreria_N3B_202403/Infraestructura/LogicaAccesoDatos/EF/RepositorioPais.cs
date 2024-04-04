using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class RepositorioPais : IRepositorioPais
    {
        private LibreriaContext _contex;

        public RepositorioPais(LibreriaContext contex)
        {
            _contex = contex;
        }

        public void Add(Pais obj)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> GetAll()
        {
            return _contex.Paises.ToList();
        }

        public Pais GetById(int id)
        {
            return _contex.Paises.SingleOrDefault(pais => pais.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
