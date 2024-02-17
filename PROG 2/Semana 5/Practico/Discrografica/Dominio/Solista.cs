using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Solista : Autor
    {
        private Sexo _sexo;
        private int _descuento;

        public Solista(string nombre, string pais, Sexo sexo, int descuento) : base(nombre, pais)
        {
            _sexo = sexo;
            _descuento = descuento;
        }

        public override int DevolverDescuento()
        {
            if (_sexo == Sexo.MASCULINO) return _descuento;
            return 0;
        }

        private void ValidarDescuento()
        {
            if (_descuento < 0) throw new Exception("El descuento no puede ser negativo");
        }

        public override void Validar()
        {
            base.Validar();
            ValidarDescuento();

        }

        public override string ToString()
        {
            return $"nombre: {_nombre} - pais: {_pais} - sexo: {_sexo} - Porcentaje de descuento: {_descuento}";
        }
    }
}
