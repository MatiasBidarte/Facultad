using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Casa : Propiedad
    {
        private int mtFrente;
        private int mtFondo;
        private decimal costoContribucion;
        private decimal impuestoPrimaria;

        public int MtFrente
        {
            get { return mtFrente; }
            set { mtFrente = value; }
        }

        public int MtFondo
        {
            get { return mtFondo; }
            set { mtFondo = value; }
        }

        public decimal CostoContribucion
        {
            get { return costoContribucion; }
            set { costoContribucion = value; }
        }

        public decimal ImpuestoPrimaria
        {
            get { return impuestoPrimaria; }
            set { impuestoPrimaria = value; }
        }

        public Casa() : base() {}

        public Casa(int mtFrente, int mtFondo, decimal costoContribucion, decimal impuestoPrimaria, Direccion direccion, DateTime fechaConstruccion) : base(direccion, fechaConstruccion)
        {
            this.mtFondo = mtFondo;
            this.mtFrente = mtFrente;
            this.costoContribucion = costoContribucion;
            this.impuestoPrimaria = impuestoPrimaria;
        }

        public override decimal Comision()
        {

            return base.Comision() + ((costoContribucion + impuestoPrimaria) / 12) * 0.10M;

        }

        public override string TipoPropiedad()
        {
            return "Casa";
        }

        public double CalcularArea()
        {
            return mtFondo * mtFrente;
        }
    }
}
