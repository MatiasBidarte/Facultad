using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Direccion : IValidable
    {
        private string calle;
        private Barrio barrio;

        public string Calle
        {
            get { return this.calle; }
            set { this.calle = value; }
        }

        public Barrio Barrio
        {
            get { return this.barrio; }
            set { this.barrio = value; }
        }

        public override string ToString()
        {
            return $"{Calle} - {Barrio.Nombre}";
        }
        public Direccion(string calle, Barrio barrio)
        {
            this.calle = calle;
            this.barrio = barrio;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(calle.Trim()))
                throw new Exception("La calle no es correcta");
            if (barrio == null)
                throw new Exception("El barrio no puede estar vacío");
        }
    }

}
