namespace EjerciciosPractico2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            
            Auto miAuto = new Auto("Fiat", "Uno", "SB5554", true, 2013, new DateTime(1990,03,01), Combustible.Nafta);
            Console.WriteLine(miAuto);

            try
            {
                miAuto.Validar();
                Console.WriteLine("Salio todo bien");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           */

            /*
            Cuenta cuenta1 = new Cuenta("Santiago", 1556456, "CA", "U$S");
            Console.WriteLine(cuenta1);
            Console.WriteLine(cuenta1.Depositar("U$S", 800));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Depositar("$", 800));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Depositar("U$S", 1200));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(795));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(1));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(1));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(1));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(1));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(1));
            Console.WriteLine(cuenta1);

            Console.WriteLine(cuenta1.Retirar(1));
            Console.WriteLine(cuenta1);
            */

            /*
            Producto p1 = new Producto("Yerba", 150);
            Producto p2 = new Producto("Azucar", 50);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Producto.ModificarDescuento(10);
            Producto p3 = new Producto("Harina", 43);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            */

            
            Cargo c1 = new Cargo("Jefe", 1500);
            Cargo c2 = new Cargo("Sub Jefe", 1500);
            Cargo c3 = new Cargo("Gerente", 11500);

            Empleado e1 = new Empleado("456465", "Jose", 18, c1, Sexo.Masculino);
            Empleado e2 = new Empleado("456465", "Carlos", 48, c1, Sexo.Masculino);
            
            List<Cargo> cargos = new List<Cargo>();
            cargos.Add(c1);
            cargos.Add(c2);
            cargos.Add(c3);

            //Console.WriteLine(cargos.Contains(c1));
            //Console.WriteLine(cargos.Contains(c2));

            //string palabra1 = "hola";
            //string palabra2 = "hola";
            //Console.WriteLine(palabra1.Equals(palabra2));
            Console.WriteLine(e1.Equals(e2));

            foreach(Cargo miCargo in cargos)
            {
                Console.WriteLine(miCargo);
            }
        }
    }
}