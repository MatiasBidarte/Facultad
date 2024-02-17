using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {

        #region Atributos
        private List<Barrio> barrios = new List<Barrio>();
        private List<Propiedad> propiedades = new List<Propiedad>();
        private List<Servicio> servicios = new List<Servicio>();
        private List<Factura> facturas = new List<Factura>();
        private static Sistema instancia;
        #endregion

        #region Singleton
        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }

        private Sistema()
        {
            PrecargaServicios();
            PrecargaBarrios();
            PrecargarCasas();
            PrecargarApartamentos();
            PrecargarMantenimiento();
            PrecargarFacturas();
        }
        #endregion



        public List<Barrio> Barrios
        {
            get { return barrios; }
        }


        public List<Propiedad> Propiedades
        {
            get { return propiedades; }
        }

        public List<Factura> Facturas
        {
            get { return facturas; }
        }

        public List<Servicio> Servicios
        {
            get { return servicios; }
        }


        private void PrecargarCasas()
        {

            AgregarCasa(new Casa(100, 200, 1000, 3000, new Direccion("San Jose 1122", ObtenerBarrio(101)), new System.DateTime(2000, 01, 01)));
            AgregarCasa(new Casa(120, 220, 1000, 3000, new Direccion("18 de julio 999 apto 102", ObtenerBarrio(102)), new System.DateTime(2000, 01, 01)));

        }


        private void PrecargarApartamentos()
        {

            AgregarApartamento(new Apartamento(101, true, 1000, new Direccion("Rambla", ObtenerBarrio(102)), new System.DateTime(2010, 01, 01)));
            AgregarApartamento(new Apartamento(201, false, 2000, new Direccion("Calle 18", ObtenerBarrio(101)), new System.DateTime(2010, 01, 01)));

        }

        private void PrecargaBarrios()
        {

            AgregarBarrio(new Barrio(101, "Barrio 1"));
            AgregarBarrio(new Barrio(102, "Barrio 2"));
            AgregarBarrio(new Barrio(103, "Barrio 3"));

        }

        private void PrecargaServicios()
        {

            AgregarServicio(new Servicio("sanitario", 1000, "Servicio de limpieza"));
            AgregarServicio(new Servicio("aire", 1000, "Servicio de fitros"));
            AgregarServicio(new Servicio("electricista", 2000, "Servicio basico"));

        }



        private void PrecargarMantenimiento()
        {

            Propiedad unaP = ObtenerPropiedad(1);
            unaP.AgregarMantenimiento(new Mantenimiento(DateTime.Now, 1000, ObtenerServicio(1)));
            unaP.AgregarMantenimiento(new Mantenimiento(DateTime.Now, 2000, ObtenerServicio(2)));
            unaP.AgregarMantenimiento(new Mantenimiento(DateTime.Now, 3000, ObtenerServicio(0)));

        }


        private void PrecargarFacturas()
        {

            Propiedad unaP = ObtenerPropiedad(1);
            AgregarFactura(new Factura(111, new DateTime(2000, 01, 01), Factura.Periodo.semanal, unaP));
            AgregarFactura(new Factura(222, new DateTime(2020, 02, 01), Factura.Periodo.mensual, unaP));


        }


        public void AgregarBarrio(Barrio barrio)
        {

            if (barrio == null)
            {
                throw new Exception("El barrio recibido no tiene datos.");
            }
            barrio.Validar();
            this.VerificarQueNoExisteElBarrio(barrio);
            barrios.Add(barrio);

        }


        public void VerificarQueNoExisteFactura(Factura factura)
        {

            if (facturas.Contains(factura))
            {
                throw new Exception($"Ya existe la factura con el numero {factura.Numero}");

            }
        }

        public void AgregarFactura(Factura factura)
        {

            if (factura == null)
            {
                throw new Exception("La factura recibida no tiene datos.");
            }
            factura.CalcularImporte();
            factura.Validar();
            this.VerificarQueNoExisteFactura(factura);
            facturas.Add(factura);

        }

        public void VerificarQueNoExisteElBarrio(Barrio barrio)
        {

            if (barrios.Contains(barrio))
            {
                throw new Exception($"Ya existe el barrio con codigo {barrio.Codigo}");

            }
        }

        public Barrio ObtenerBarrio(int codigo)
        {
            foreach (Barrio item in barrios)
            {
                if (item.Codigo == codigo)
                {
                    return item;

                }
            }
            return null;
        }

        public Servicio ObtenerServicio(int id)
        {
            foreach (Servicio item in servicios)
            {
                if (item.Id == id)
                {
                    return item;

                }
            }
            return null;
        }

        public Propiedad ObtenerPropiedad(int id)
        {
            Propiedad propiedad = null;
            foreach (Propiedad item in propiedades)
            {
                if (item.Id == id)
                {
                    return item;

                }
            }
            return propiedad;
        }

        public void AgregarCasa(Casa casa)
        {

            if (casa == null)
            {
                throw new Exception("La casa recibida no tiene datos.");
            }
            casa.Validar();
            propiedades.Add(casa);

        }


        public void AgregarApartamento(Apartamento apartamento)
        {

            if (apartamento == null)
            {
                throw new Exception("El apartamento recibido no tiene datos.");
            }
            apartamento.Validar();
            propiedades.Add(apartamento);


        }

        public void AgregarServicio(Servicio servicio)
        {

            if (servicio == null)
            {
                throw new Exception("El barrio recibido no tiene datos.");
            }
            servicio.Validar();
            servicios.Add(servicio);

        }


        public List<Propiedad> CasasPorMetro(int mt)
        {
            List<Propiedad> aux = new List<Propiedad>();
            foreach (Propiedad propiedad in propiedades)
            {
                if (propiedad is Casa)
                {
                    Casa unaC = (Casa)propiedad;
                    if (unaC.MtFrente > mt)
                    {
                        aux.Add(propiedad);
                    }
                }

            }
            return aux;
        }

        public List<Apartamento> GastosApartamentos()
        {
            List<Apartamento> aux = new List<Apartamento>();
            foreach (Propiedad propiedad in propiedades)
            {
                if (propiedad is Apartamento)
                {
                    Apartamento unP = (Apartamento)propiedad;
                    aux.Add(unP);

                }

            }
            aux.Sort();
            return aux;
        }

        public List<Factura> FacturasOrdenadasPorNumero()
        {
            List<Factura> aux = new List<Factura>();
            foreach (Factura item in facturas)
            {
                aux.Add(item);
            }
            aux.Sort();
            return aux;
        }


        public List<Factura> FacturasPorFecha(DateTime desde, DateTime hasta)
        {
            List<Factura> aux = new List<Factura>();
            foreach (Factura item in facturas)
            {
                if (item.Fecha >= desde && item.Fecha <= hasta)
                {
                    aux.Add(item);
                }
            }
            aux.Sort();
            return aux;
        }



    }
}
