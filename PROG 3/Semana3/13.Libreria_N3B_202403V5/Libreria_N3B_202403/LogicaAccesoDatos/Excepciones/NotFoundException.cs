using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class NotFoundException : RepositorioException
    {
        public NotFoundException(): base("No se encontrò la informaciòn solicitada.") { }

    }
}
