using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Fan : Usuario
    {
        public Musico MusicoFavorito { get; set; }
        
        public Fan(string email, string pass) : base(email, pass)
        {
        }

        public override string Tipo()
        {
            return "Fan";
        }

        public void HacerFavorito(Musico m)
        {
            if (m == null) throw new Exception("Musico nulo");
            if (MusicoFavorito != null && MusicoFavorito.Equals(m)) throw new Exception("El musico ya es el mismo");
            MusicoFavorito = m;
        }
    }
}
