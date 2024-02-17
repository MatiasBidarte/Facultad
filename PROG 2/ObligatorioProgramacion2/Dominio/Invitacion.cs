using Dominio.Interfaces;
using System;
namespace Dominio
{
    public class Invitacion : IValidable
    {
        private static int s_ultId = 1;
        private int _id;
        private Miembro _miembroSolicitante;
        private Miembro _miembroSolicitado;
        private Estado _estado;
        private DateTime _fecha;
        /* Se inicializa el estado en PENDIENTE_APROBACION desde el constructor */
        public Invitacion(Miembro miembroSolicitante, Miembro miembroSolicitado)
        {
            _id = s_ultId;
            s_ultId++;
            _miembroSolicitante = miembroSolicitante;
            _miembroSolicitado = miembroSolicitado;
            _estado = Estado.PENDIENTE_APROBACION;
            _fecha = DateTime.Now;
        }

        public DateTime Fecha
        {
            get { return _fecha; }
        }

        public Miembro MiembroSolicitante
        {
            get { return _miembroSolicitante; }
        }

        public Miembro MiembroSolicitado
        {
            get { return _miembroSolicitado; }
        }

        public int ID
        {
            get { return _id; }
        }

        public Estado Estado { get { return _estado; } }

        private void ValidarMiembroSolicitado()
        {
            if (_miembroSolicitado == null) throw new Exception("El miembro solicitado no puede ser nulo");
        }

        private void ValidarMiembroSolicitante()
        {
            if (_miembroSolicitante == null) throw new Exception("El miembro solicitante no puede ser nulo");
        }

        /*Metodo que valida una invitacion, y todo lo que requiere para que sea valida*/
        private void ValidarInvitacion()
        {
            if (_miembroSolicitante.Equals(_miembroSolicitado)) throw new Exception("El miembro solicitado es igual al solicitante");
            _miembroSolicitante.ValidarMiembroNoEsAmigo(_miembroSolicitado);
            if (_estado != Estado.PENDIENTE_APROBACION) throw new Exception("El estado de la solicitud debe de estar en pendiente aprobacion");
        }
        public void Validar()
        {
            ValidarMiembroSolicitante();
            ValidarMiembroSolicitado();
            ValidarInvitacion();
        }

        public void AceptarInvitacion(Miembro solicitado)
        {
            ValidarInvitacion();

            _estado = Estado.APROBADA;
            _miembroSolicitante.AgregarAmigo(solicitado);
            solicitado.AgregarAmigo(_miembroSolicitante);
        }

        public void RechazarInvitacion()
        {
            ValidarInvitacion();
            _estado = Estado.RECHAZADA;
        }

        public override string ToString()
        {
            return $"Id: {_id} - Miembro solicitante: {_miembroSolicitante} - Miembro solicitado: {_miembroSolicitado}";
        }

    }
}

