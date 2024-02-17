using Dominio.Interfaces;
using System;
namespace Dominio
{
    public class Reaccion : IValidable
    {
        private TipoReaccion _tipoReaccion;
        private Miembro _creador;

        public Reaccion(TipoReaccion tipoReaccion, Miembro creador)
        {
            _tipoReaccion = tipoReaccion;
            _creador = creador;
        }

        public Miembro Creador
        {
            get { return _creador; }
        }

        public TipoReaccion TipoReaccion
        {
            get { return _tipoReaccion; }
        }

        private void ValidarCreador()
        {
            if (_creador == null) throw new Exception("El creador no puede ser nulo");
        }

        public void Validar()
        {
            ValidarCreador();
        }

        public override string ToString()
        {
            return $"Creador: {_creador} - Reaccion: {_tipoReaccion}";
        }
    }
}

