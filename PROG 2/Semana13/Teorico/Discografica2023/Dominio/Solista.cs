using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Solista : Musico
    {
        private Sexo _sexo;
        private double _porcentajeDescuento;

        public Solista(string nombre, string pais, Sexo sexo, double descuento) : base(nombre, pais)
        {
            this._sexo = sexo;
            this._porcentajeDescuento = descuento;
        }

        
        public override void Validar()
        {
            base.Validar();
            ValidarDescuento();
        }

        private void ValidarDescuento()
        {
            if (_porcentajeDescuento < 0) throw new Exception("El descuento no puede ser menor a 0");
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre} - Pais: {_pais} - Sexo: {_sexo} - Porcentaje descuento: {_porcentajeDescuento}%";
        }

        public override double ObtenerDescuento()
        {
            double descuento = 0;
            if (_sexo == Sexo.Masculino) descuento = _porcentajeDescuento;
            return descuento;
        }

        public override string Tipo()
        {
            return "Solista";
        }
    }
}
