using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.Entidades
{
    public class Autor : IValidable, IEntity, IEquatable<Autor>
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaDefuncion { get; set; } = null;
        public string Nacionalidad { get; set; }
        public int NumeroReferencia { get; set; }

        // Propiedades de navegación
       // public List<Telefono> MisTelefonos { get; set; }
        public Pais MiPais { get; set; }
        public List<Tema> MisTemas {  get; set; } 
        public required Direccion MiDireccion { get; set; }


        public void Validar()
        {
        }

        public override string ToString()
        {
            return $"{this.Nombre} {this.FechaNacimiento} {this.FechaDefuncion}";
        }

        public bool Equals(Autor other)
        {
            return Id.Equals(other.Id);
        }


    }
}
