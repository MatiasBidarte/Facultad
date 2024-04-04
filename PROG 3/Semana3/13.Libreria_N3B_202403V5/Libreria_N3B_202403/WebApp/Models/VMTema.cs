using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class VMTema
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 5, ErrorMessage = "Largo del nombre es 2-10")]
        public string? Nombre { get; set; }


        [StringLength(10, MinimumLength = 5, ErrorMessage = "Largo del descripcion es 5-10")]
        public string? Descripcion { get; set; }
    }
}
