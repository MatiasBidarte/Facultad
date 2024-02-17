using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Dominio
{
    public class Miembro : Usuario, IComparable<Miembro>
    {

        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private List<Miembro> _amigos;
        private bool _estaBloqueado;

        public Miembro(string email, string contrasenia, string nombre, string apellido, DateTime fechaNacimiento) : base(email, contrasenia)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _amigos = new List<Miembro>();
            _estaBloqueado = false;
        }

        public Miembro(string email, string contrasenia, string nombre, string apellido, DateTime fechaNacimiento, bool estaBloqueado) : base(email, contrasenia)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _amigos = new List<Miembro>();
            _estaBloqueado = estaBloqueado;
        }

        public Miembro()
        {
            _amigos = new List<Miembro>();
        }

        public bool EstaBloqueado
        {
            get { return _estaBloqueado; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public void ValidarMiembroNoEsAmigo(Miembro m)
        {
            if (_amigos.Contains(m)) throw new Exception("El usuario solicitante ya esta en la lista de amigos del solicitado");
        }

        public bool EsAmigo(Miembro m)
        {
            bool retorno = false;
            if (_amigos.Contains(m)) retorno = true;
            return retorno;
        }

        public void AgregarAmigo(Miembro m)
        {
            _amigos.Add(m);
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser nulo");
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(_apellido)) throw new Exception("El apellido no puede ser nulo");
        }

        private void ValidarFechaNacimiento()
        {
            if (_fechaNacimiento == null) throw new Exception("La fecha de nacimiento no puede ser null");
        }

        public override void Validar()
        {
            base.Validar();
            ValidarNombre();
            ValidarApellido();
            ValidarFechaNacimiento();

        }

        public void Bloquear()
        {
            _estaBloqueado = true;
        }

        public void Desbloquear()
        {
            _estaBloqueado = false;
        }

        public override string Tipo()
        {
            return "Miembro";
        }

        public void CambiarContrasenia(string nuevaCont)
        {
            _contrasenia = nuevaCont;
        }

        public override string ToString()
        {
            return $"Usuario: {_nombre} {_apellido}";
        }

        public int CompareTo(Miembro? other)
        {
            int orden = _apellido.CompareTo(other._apellido);
            if (orden == 0) orden = _nombre.CompareTo(other._nombre);
            return orden;
        }
    }
}