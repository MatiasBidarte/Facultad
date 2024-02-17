using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPractico2
{
    internal class Auto
    {
       
        private string _marca;
        private string _modelo;
        private string _matricula;
        private bool _exoneraImpuestos;
        private int _anio;
        private DateTime _fechaProduccion;
        private Combustible _combustible;

        public Auto(string marca, string modelo, string matricula, bool exoneraImpuestos, int anio, DateTime fechaProduccion, Combustible combustible)
        {
            _marca = marca;
            _modelo = modelo;
            _matricula = matricula;
            _exoneraImpuestos = exoneraImpuestos;
            _anio = anio;
            _fechaProduccion = fechaProduccion;
            _combustible = combustible;
            
        }

        private void ValidarMatricula()
        {
            if (string.IsNullOrEmpty(_matricula) || _matricula.Length != 7) throw new Exception("La matricula debe tener largo 7");
        }

        private void ValidarMarca()
        {
            if( string.IsNullOrEmpty(_marca) || _marca.Length < 3) throw new Exception("La marca debe tener al menos 3 caracteres");
        }

        public void Validar()
        {
            ValidarMatricula();
            ValidarMarca();
        }
        
        private double CalcularPatente()
        {
            double total = 17000;
            if(_anio < 2015)
            {
                //Expresion ternaria
                //total = _exoneraImpuestos ? 10000 : 12000;

                if (_exoneraImpuestos) total = 10000;
                else total = 12000;
            }

            return total;
        }

        public override string ToString()
        {
            return $"Marca: {_marca} - Modelo: {_modelo} - Año: {_anio} - Exonera: {_exoneraImpuestos} - Patente: ${CalcularPatente()} - Fecha: {_fechaProduccion.ToLongDateString()} - Combustible: {_combustible} - Combustible entero: {(int)_combustible}";
        }

    }
}
