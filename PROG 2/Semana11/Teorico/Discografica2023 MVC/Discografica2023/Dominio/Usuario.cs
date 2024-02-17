using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        public string Email { get;  }
        public string Pass { get;  }
        public Usuario(string email, string pass)
        {
            Email = email;
            Pass = pass;
        }

        public abstract string Tipo();

        public void Validar()
        {
            //valido cosas
        }

    }
}
