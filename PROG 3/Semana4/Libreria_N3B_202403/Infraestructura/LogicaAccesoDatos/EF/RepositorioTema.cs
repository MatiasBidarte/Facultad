using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;


namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class RepositorioTema : IRepositorioTema
    {
        private LibreriaContext _context;

        public RepositorioTema (LibreriaContext libreriaContext)
        {
            _context = libreriaContext;
        }


        public void Add(Tema obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            obj.Validar();
            _context.Temas.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tema tema = GetById(id);
            if (tema == null)
            {
                throw new NotFoundException();
            }
            _context.Temas.Remove(tema);
            _context.SaveChanges();
        }

        public IEnumerable<Tema> GetAll()
        {
            return _context.Temas.ToList();
        }

        public Tema GetById(int id)
        {
            // sentencia linq
            // tema => tema funcion lambda

            return _context.Temas.FirstOrDefault(tema => tema.Id == id);

            //foreach (Tema unTema in _context.Temas.ToList())
            //{
            //    if (unTema.Id == id)
            //        return unTema;

            //}
            //return null;

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
            _context.Temas.Update(tema);
            _context.SaveChanges(true);                    
        }
    }
}
