using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Banda : Musico
    {
        private int _cantIntegrantes;
        private static double s_porcentajeDescuentoComun = 10;

        public Banda(string nombre, string pais, int cantIntegrantes) : base(nombre, pais)
        {
            this._cantIntegrantes = cantIntegrantes;
        }

        public int CantIntegrantes
        {
            get { return _cantIntegrantes; }
            set { _cantIntegrantes = value;}
        }

        public Banda() { }

        public override void Validar() 
        {
            base.Validar();
            ValidarCantIntegrantes();
        }

        private void ValidarCantIntegrantes()
        {
            if (_cantIntegrantes <= 1) throw new Exception("La banda no puede tener menos de 2 integrantes");
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre} - Pais: {_pais} - Integrantes: {_cantIntegrantes}";
        }

        public override double ObtenerDescuento()
        {
            double descuento = 0;
            if (_cantIntegrantes > 4) descuento = s_porcentajeDescuentoComun;
            return descuento;
        }

        public override string Tipo()
        {
            return "Banda";
        }
    }
}
