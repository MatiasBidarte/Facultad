using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class ArgumentNullRepositorioException : RepositorioException
    {
        public ArgumentNullRepositorioException(): base("No se recibio informaciòn vàlida.") { }

    }
}
