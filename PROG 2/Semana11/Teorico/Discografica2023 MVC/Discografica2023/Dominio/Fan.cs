using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
