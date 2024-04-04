using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class RepositorioAutor : IRepositorioAutor
    {
        private LibreriaContext _contex;

        public RepositorioAutor(LibreriaContext contex)
        {
            _contex = contex;
        }

        public void Add(Autor obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            if (nameExists(obj.Nombre))
            {
                throw new ArgumentNullRepositorioException();
            }

            obj.Validar();
            try
            {
                // Es importante que Id venga en 0, podria ponerlo siempre antes de hacer el add
                 obj.Id = 0;
                _contex.Autores.Add(obj);
                _contex.SaveChanges();
            }
            catch (Exception e)
            {
                // logear el problema
                throw new Exception("Hubo un problema intenta en 5");
            }
        }
        private bool nameExists(string name)
        {
            // En esos casos, puede participar de forma explícita en la evaluación de cliente
            // si llamada a métodos como AsEnumerable o ToList(AsAsyncEnumerable o ToListAsync para async).
            // Al usar AsEnumerable se haría streaming de los resultados, pero al usar ToList se almacenarían
            // en búfer mediante la creación de una lista, que también consume memoria adicional.
            // Como si se realizara la enumeración varias veces, el almacenamiento de los resultados en una lista es más útil,
            // ya que solo hay una consulta a la base de datos. En función del uso determinado, debe evaluar qué método
            // es más útil para cada caso.


            Autor unAutor = _contex.Autores
            .AsEnumerable()
            .FirstOrDefault(autor => autor.Nombre == name.ToLower());
            
            return unAutor != null;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
                  
        public void Update(int id, Autor obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autor> GetAll()
        {
            return _contex.Autores.ToList();
        }

        public Autor GetById(int id)
        {
            Autor unAutor = null;
            unAutor = _contex.Autores.FirstOrDefault(autor => autor.Id == id);
            if (unAutor == null)
            {
                throw new NotFoundException($"No se encontro el autor con id {id}");
            }
            return unAutor;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}