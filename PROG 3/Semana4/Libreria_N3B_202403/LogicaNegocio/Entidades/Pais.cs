using LogicaNegocio.IntefacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Pais : IValidable, IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Autor> MisAutores { get; set; }
        public void Validar()
        {
        }
    }
}
