using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dominio.Interfaces;

namespace Dominio
{
    public class Barrio: IValidable, IEquatable<Barrio>
    {
        private int codigo;
        private string nombre;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Barrio(int codigo)
        {
            this.codigo = codigo;          
        }

        public Barrio(int codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public void Validar()
        {
            ValidarCodigo();
            ValidarNombre();
        }

        private void ValidarCodigo()
        {
            if (codigo <= 100) {
                throw new Exception("El código del barrio debe ser mayor que 100");
            }
        }

        private  void ValidarNombre()
        {
            if (nombre.Length <= 3) {
                throw new Exception("El nombre del barrio debe tener al menos 4 caracteres");
            }
        }

        public override int GetHashCode()
        {
            return codigo;
        }


        public bool Equals(Barrio other)
        {
            return other != null && codigo == other.codigo;
        }
    }
}
