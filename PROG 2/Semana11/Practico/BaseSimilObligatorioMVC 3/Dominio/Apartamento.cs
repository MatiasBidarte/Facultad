using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Apartamento : Propiedad, IComparable<Apartamento>
    {
        private int numero;
        private bool vistaCalle;
        private decimal gastosComunes;

        public decimal GastosComunes
        {
            get { return gastosComunes; }
        }

        public Apartamento(int numero, bool vistaCalle, decimal gastosComunes, Direccion direccion, DateTime fechaConstruccion) : base(direccion, fechaConstruccion)
        {
            this.numero = numero;
            this.vistaCalle = vistaCalle;
            this.gastosComunes = gastosComunes;
        }

        public int CompareTo(Apartamento other)
        {            
            return gastosComunes.CompareTo(other.gastosComunes);
        }

        public override decimal Comision()
        {
            return  base.Comision() + gastosComunes * 0.15M;
        }

        public override string TipoPropiedad()
        {
            return "Apartamento";
        }
    }
}
