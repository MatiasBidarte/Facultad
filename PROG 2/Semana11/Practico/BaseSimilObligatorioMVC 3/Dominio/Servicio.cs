using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Servicio : IValidable
    {
        private int id;
        private static int ultId;
        private string tipo;
        private decimal costoBase;
        private string nombre;


        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Tipo
        {
            get { return tipo; }
        }

        public decimal CostoBase
        {
            get { return costoBase; }
        }

        public Servicio(string tipo, decimal costoBase, string nombre)
        {
            id = ultId++;
            this.tipo = tipo;
            this.costoBase = costoBase;
            this.nombre = nombre;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarTipo();
            ValidarCostoBase();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
                throw new Exception("El nombre no puede estar vacío");
        }
        private void ValidarTipo()
        {
            if (string.IsNullOrEmpty(tipo.Trim()))
                throw new Exception("El tipo no puede estar vacío");
        }
        private void ValidarCostoBase()
        {
            if (this.costoBase < 0)
                throw new Exception("El costo base debe ser positivo");
        }

    }
}
