
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaAccesoDatos.Excepciones;

namespace LogicaAccesoDatos.Listas
{
    public class RepositorioTema: IRepositorioTema
    {
        private static List<Tema> _temas = new List<Tema>();

        public List<Tema> Temas
        { 
            get { return _temas; }
        }


        public Tema GetById(int id)
        {
            foreach (var item in _temas)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Tema GetByName(string nombre)
        {
            foreach (var item in _temas)
            {
                if (item.Nombre == nombre)
                {
                    return item;
                }
            }
            return null;
        }

        public void Add(Tema tema)
        {
            if (tema == null)
            {
                throw new ArgumentNullRepositorioException("el tema no puede ser nulo");
            }
            tema.Validar();
            _temas.Add(tema);
        }

        public void Delete(int id)
        {
            Tema tema = GetById(id);
            if (tema == null)
            {
                throw new NotFoundException("Tema a eliminar no encontrado");
            }
            _temas.Remove(tema);
        }

        public IEnumerable<Tema> GetAll()
        {
            return _temas;
        }

        IEnumerable<Tema> IRepositorioTema.GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Tema tema)
        {
            Tema _tema = GetById(id) ?? throw new Exception("No se encontro el id");
            _tema.Update(tema);
        }

        List<Tema> IRepositorio<Tema>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
