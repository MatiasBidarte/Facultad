using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Interfaces;

namespace Dominio
{
    public abstract class Propiedad: IValidable
    {
        private int id;
        private static int ultId;
        private Direccion direccion;
        private List<Mantenimiento> mantenimientos = new List<Mantenimiento>();
        private static decimal CostoBaseComision = 1000;
        private DateTime fechaConstruccion;

        public int Id
        {
            get { return id; }
        }

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public DateTime FechaConstruccion
        {
            get { return fechaConstruccion; }
        }

        public List<Mantenimiento> Mantenimientos
        {
            get { return mantenimientos;}
        }

        public Propiedad(Direccion direccion, DateTime fechaConstruccion)
        {
            this.id = ultId++;
            this.direccion = direccion;
            this.fechaConstruccion = fechaConstruccion;
        }

        public Propiedad()
        {
            this.id = ultId++;
        }


        public void Validar()
        {
            ValidarDireccion();
        }
     
        private void ValidarDireccion()
        {
            if (direccion == null)
            {
                throw new Exception("La direccoin no puede estar vacio");
            }
            direccion.Validar();
        }


        public void AgregarMantenimiento(Mantenimiento mantenimiento)
        {

                if (mantenimiento == null)
                {
                    throw new Exception("El mantenimiento recibido no tiene datos.");
                }
                mantenimiento.Validar();
                mantenimientos.Add(mantenimiento);
        }

        public abstract string TipoPropiedad();

        public virtual decimal Comision()
        {
            return CostoBaseComision + mantenimientos.Count > 10 ? 500 : 0;
        }

        public override string ToString()
        {
            string texto = $"Propiedad {this.Id} - Direccion: {this.Direccion} -  Tipo: {this.TipoPropiedad()} - Comision: $U {this.Comision()}\n";

            if (this.Mantenimientos.Count == 0) {
                texto += "La propiedad no tiene mantenimientos registrados";
            }
            else { 
                texto+=$"Tiene {this.Mantenimientos.Count} mantenimientos realizados. Detalle: \n";
                foreach (Mantenimiento mantenimiento in this.Mantenimientos)
                {
                    texto += $" Fecha: {mantenimiento.Fecha} - Servicio: ({mantenimiento.Servicio.Id}) {mantenimiento.Servicio.Nombre} \n";
                }
            }
                       
            
            return texto;
        }

    }
}
