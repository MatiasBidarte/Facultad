using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPractico2
{
    internal class Producto
    {
        private int _id;
        private static int s_ultId = 1;
        private string _nombre;
        private double _precio;
        private static int s_descuento = 5;

        public Producto(string nombre, double precio)
        {
            _nombre = nombre;
            _precio = precio;
            _id = s_ultId;
            s_ultId++;
        }

        public static int Descuento 
        { 
            get { return s_descuento; } 
            set { s_descuento = value;}
        }

        public static void ModificarDescuento(int descuentoNuevo)
        {
            s_descuento = descuentoNuevo;
        }

        public override string ToString()
        {
            return $"Id: {_id} - {_nombre} ${_precio} - Descuento: {s_descuento}";
        }
    }
}
