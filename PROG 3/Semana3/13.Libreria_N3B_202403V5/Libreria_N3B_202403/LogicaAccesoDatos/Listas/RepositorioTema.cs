
using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;

namespace LogicaAccesoDatos.Listas
{
    public class RepositorioTema: IRepositorioTema
    {
        private static List<Tema> _temas = new List<Tema>();

       
        public void Add(Tema obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            obj.Validar();
            _temas.Add(obj);
        }

        public void Delete(int id)
        {
            Tema tema = GetById(id);
            if (tema == null)
            {
                throw new NotFoundException();
            }
            _temas.Remove(tema);
        }

        public IEnumerable<Tema> GetAll()
        {
            return _temas;
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

        public IEnumerable<Tema> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Tema obj)
        {
            Tema tema = GetById(id);
            if (tema == null)
            {
                throw new NotFoundException();
            }
            tema.Update(obj);        
        }



        //public Tema? BuscarPorNombre(string? nombre)
        //{
        //    foreach (var item in _temas)
        //    {
        //        if (item.Nombre == nombre)
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}

    }
}
