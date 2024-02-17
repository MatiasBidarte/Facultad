using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public int Pin { get; }
        public Administrador(string email, string pass, int pin) : base(email, pass)
        {
            Pin = pin;
        }

        public override string Tipo()
        {
            return "Administrador";
        }
    }
}
