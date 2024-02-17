using System;
namespace Dominio
{
    public class Administrador : Usuario
    {
        
        public Administrador(string email, string contrasenia) : base(email, contrasenia)
        {

        }

        public override void Validar()
        {
            base.Validar();
        }

        public override string Tipo()
        {
            return "Admin";
        }

        public override string ToString()
        {
            return $"Admin: {_email}";
        }
    }
}



