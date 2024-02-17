using Dominio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consola
{
    internal class Program
    {
        static Sistema sistema;

        static void Main(string[] args)
        {
            sistema = Sistema.Instancia;

            bool salir = false;
            string opcion = string.Empty;

            while (!salir)
            {
                MostrarMenu();
                opcion = PedirPalabras("Ingrese opcion");

                switch (opcion)
                {
                    case "1":
                        AltaCliente();
                        break;
                    case "2":
                        AsignarCuentaACliente();
                        break;
                    case "3":
                        MostrarClientesYCuentas();
                        break;
                    case "4":
                        ListarClientesConS();
                        break;
                    case "5":
                        //
                        break;
                    case "0":
                        salir = true;
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        MostrarError("Opcion invalida");
                        break;
                }
            }
        }

        static string PedirPalabras(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        static Moneda PedirTipoMoneda(string mensaje)
        {
            Console.WriteLine(mensaje);
            string monedaString = Console.ReadLine();
            Moneda moneda = Moneda.UYU;

            switch (monedaString)
            {
                case "UYU":
                    moneda = Moneda.UYU;
                    break;
                case "USD":
                    moneda =  Moneda.USD;
                    break;
                case "EUR":
                    moneda =  Moneda.EUR;
                    break;
                default:
                    MostrarError("TIpo de moneda erronea");
                    break;
            }
            return moneda;
        }

        static void MostrarError(string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(err);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static int PedirNumeros(string mensaje)
        {
            bool exito = false;
            int num = 0;

            while (!exito)
            {
                Console.WriteLine();
                Console.WriteLine(mensaje);
                exito = int.TryParse(Console.ReadLine(), out num);
                if (!exito)
                {
                    MostrarError("Debe ingresar solo numeros enteros");
                }
            }
            return num;
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ---- MENU ----");
            Console.WriteLine("1 - Alta cliente");
            Console.WriteLine("2 - Agregar cuenta a cliente");
            Console.WriteLine("3 - Listar clientes y cuentas");
            Console.WriteLine("4 - Listar clientes con S");
            Console.WriteLine("5 - Parte 5");
            Console.WriteLine("0 - Salir");
        }

        static void AltaCliente()
        {
            string cedula = PedirPalabras("Ingrese su cedula");
            string nombre = PedirPalabras("Ingrese su nombre");

            try
            {
                if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre)) throw new Exception("No pueden ser vacios los campos nombre y cedula");
                Cliente cliente = new Cliente(cedula, nombre);
                sistema.AltaCliente(cliente);
                MostrarExito("Cliente agregado");

            }catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }

        static void AsignarCuentaACliente()
        {
            Console.Clear();
            Moneda moneda = PedirTipoMoneda("Ingrese la moneda de la cuenta");
            string cedula = PedirPalabras("Ingrese la cedula del cliente");

            try
            {
                if (string.IsNullOrEmpty(cedula)) throw new Exception("No pueden ser vacios los campos nombre y cedula");
                Cuenta cuenta = new Cuenta(moneda);
                sistema.AgregarCuentaACliente(cedula, cuenta);
                MostrarExito("Cuenta agregada con exito");
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        static void MostrarClientesYCuentas()
        {
            Console.Clear();
            foreach(Cliente c in sistema.Clientes)
            {
                Console.WriteLine(c);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void ListarClientesConS()
        {
            Console.Clear();
            Console.WriteLine("Listado de clientes cuyo nombre empieza con S: ");

            List<Cliente> clientesConS = sistema.ClientesEmpiezaConS();

            if (clientesConS.Count == 0) MostrarError("No hay clientes que cuyo nombre comience con S");
            else
            {
                foreach(Cliente c in clientesConS)
                {
                    Console.WriteLine(c);
                    Console.WriteLine();
                }

            }
        }

        static void ListarClientesConMas2Cuentas()
        {
            Console.Clear();
            Console.WriteLine("Listado de clientes que tienen mas de 2 cuentas: ");

            List<Cliente> clientes = sistema.ClientesConMasDe2Cuentas();

            if (clientes.Count == 0) MostrarError("No hay clientes que tengan mas de 2 cuentas");
            else
            {
                foreach (Cliente c in clientes)
                {
                    Console.WriteLine(c);
                    Console.WriteLine();
                }

            }
        }
    }

}