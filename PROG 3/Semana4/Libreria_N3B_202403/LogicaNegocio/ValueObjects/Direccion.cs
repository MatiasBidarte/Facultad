using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public record Direccion
    {
        public string Calle { get; }
        public string Nro { get; }

        public Direccion(string calle, string nro)
        {
            Calle = calle;
            Nro = nro;
            Validar();
        }

        private void Validar()
        {
            ValidarCalle();
        }
        private void ValidarCalle()
        { 
         if (string.IsNullOrEmpty(Calle))
            {
                throw new Exception("DIRECCON");
            }
        }
    }


}
}
