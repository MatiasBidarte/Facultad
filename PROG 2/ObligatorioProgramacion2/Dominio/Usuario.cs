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
        protected string _email;
        protected string _contrasenia;

        public Usuario(string email, string contrasenia)
        {
            _email = email;
            _contrasenia = contrasenia;
        }

        public Usuario() {}

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Contrasenia
        {
            get { return _contrasenia;  }
            set { _contrasenia = value;  }
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(_email)) throw new Exception("El email no puede ser vacio");
        }
        private void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(_contrasenia)) throw new Exception("La constraseña no puede ser vacia");
        }
        public virtual void Validar()
        {
            ValidarEmail();
            ValidarContrasenia();
        }

        public abstract string Tipo();

        public override bool Equals(object? obj)
        {
            Usuario user = obj as Usuario;
            return user != null && _email.Equals(user._email);
        }
    }
}
