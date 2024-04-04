using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Excepciones.Auto;

namespace Dominio.EntidadesAgregados
{
    public class Auto: IValidable
    {
        public Auto(){}

        public int Id { get; set; }
        public string Matricula { get; set; }
        public int Puertas { get; set; }

        public void Validar()
        {
            if (Puertas != 2 )
            {
                throw new PuertasInvalidasException("debe tener 2 puertas");
            }

            if (string.IsNullOrEmpty(Matricula) || Matricula.Length != 6)
            {
                throw new MatriculaInvalidaException("La matricula debe existir y debe de tener 6 caracteres");
            }
        }
    }
}
