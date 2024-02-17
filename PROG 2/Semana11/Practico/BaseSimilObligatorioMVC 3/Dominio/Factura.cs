using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dominio.Interfaces;

namespace Dominio
{
    public class Factura: IValidable, IEquatable<Factura>, IComparable<Factura>
    {


        public enum Periodo { semanal=7,quincenal=15,mensual=30}

        private decimal importe;

        public int Numero { get; set; }
        public DateTime Fecha { get; set; }

        public Propiedad Propiedad { get; set; }

        public Periodo CicloFacturacion { get; set; }


        public decimal Importe
        {
            get { return importe; }
            private set {importe = value; }
        }
        
        public Factura()
        { }

        public Factura(int numero, DateTime fecha, Periodo ciclo, Propiedad propiedad)
        {
            Numero = numero;
            Fecha = fecha;
            CicloFacturacion = ciclo;
            Propiedad = propiedad;
            this.CalcularImporte();
        }

        public void Validar()
        {
           // todo
        }

        public bool Equals(Factura other)
        {
            return other != null && Numero == other.Numero;
        }

        public void CalcularImporte()
        {
            if (this.Propiedad == null) {
                throw new Exception("La factura debe tener asociada una propiedad para poder calcular el importe");
            }
            if (this.CicloFacturacion == 0) {
                throw new Exception("La propiedad debe tener cargado un cicli de facturación para poder calcular el importe");
            }

            decimal valor = 0;

            switch (this.CicloFacturacion) {
                case Factura.Periodo.semanal:
                    valor = this.Propiedad.Comision() / 4;
                    break;
                case Factura.Periodo.quincenal:
                    valor = this.Propiedad.Comision() / 2;
                    break;
                case Factura.Periodo.mensual:
                    valor = this.Propiedad.Comision();
                    break;

            }

            this.Importe = valor;
        }

        public int CompareTo([AllowNull] Factura other)
        {
            return Numero.CompareTo(other.Numero);
        }
    }
}
