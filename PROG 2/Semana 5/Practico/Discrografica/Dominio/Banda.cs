using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Banda : Autor
    {
        private int _cantPers;
        private static int s_descuento = 5;

        public Banda(int cantPers, string nombre, string pais) : base(nombre, pais)
        {
            _cantPers = cantPers;
        }

        public override int DevolverDescuento()
        {
            if (_cantPers >= 4) return s_descuento;
            return 0;
        }

        private void ValidarIntegrantes()
        {
            if (_cantPers <= 0) throw new Exception("Los integrantes no pueden ser negativos, o 0");
        }

        public override void Validar()
        {
            base.Validar();
            ValidarIntegrantes();
        }

        public override string ToString()
        {
            return $"nombre: {_nombre} - pais: {_pais} - cantidad de integrantes: {_cantPers}";
        }
    }
}
