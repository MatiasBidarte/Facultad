using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Ordenamiento
{
    internal class OrdenCargoNombreDesc : IComparer<Cargo>
    {
        public int Compare(Cargo? x, Cargo? y)
        {
            return x.Nombre.CompareTo(y.Nombre) * -1;
        }
    }
}
