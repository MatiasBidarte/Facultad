using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Mantenimiento : IValidable, IEquatable<Mantenimiento>
    {

        public int Id { get; private set; }
        private static int uldId;
        public DateTime Fecha { get; set; }
        public decimal CostoManoObra { get; set; }
        public Servicio Servicio { get; set; }


        public Mantenimiento()
        {
            Id = uldId++;
        }

        public Mantenimiento(DateTime fecha, Decimal costoManoObra, Servicio servicio)
        {
            Id = uldId++;
            Fecha = fecha;
            CostoManoObra = costoManoObra;
            Servicio = servicio;
        }

        public decimal Total()        
        {
            return CostoManoObra + Servicio.CostoBase;
        }

        public void Validar()
        {
            ValidarServicio();
            ValidarFecha();
            ValidarCostoManoObra();
        }

        private void ValidarServicio()
        {
            if (Servicio == null)
            {
                throw new Exception("No se recibio un servicio válido");
            }
        }

        private void ValidarCostoManoObra()
        {
            if (CostoManoObra <= 0)
            {
                throw new Exception("El costo de mano de obra no es correcto");
            }
        }

        private void ValidarFecha()
        {
            if (Fecha == DateTime.MinValue || Fecha == DateTime.MaxValue || Fecha < DateTime.Today)
            {
                throw new Exception("No se recibió una fecha válida");
            }
        }

        public bool Equals(Mantenimiento other)
        {
            return other != null && Fecha == other.Fecha && Servicio.Id == other.Servicio.Id;
        }


    }
}
