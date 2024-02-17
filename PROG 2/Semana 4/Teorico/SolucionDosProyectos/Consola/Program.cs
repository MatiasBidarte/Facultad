using Dominio;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

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
                        AltaCargo();
                        break;
                    case "2":
                        //AltaEmpleado();
                        break;
                    case "3":
                        MostrarEmpleados();
                        break;
                    case "4":
                        MostrarCargos();
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

        static void MostrarError(string err)
        {
            //Console.BackgroundColor = ConsoleColor.Red;
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
            Console.WriteLine("1 - Alta Cargo");
            Console.WriteLine("2 - Alta Empleado");
            Console.WriteLine("3 - Listar Empleados");
            Console.WriteLine("4 - Listar Cargos");
            Console.WriteLine("0 - Salir");
        }

        static void MostrarEmpleados()
        {
            foreach (Empleado e in sistema.Empleados)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        static void MostrarCargos()
        {
            foreach (Cargo c in sistema.Cargos)
            {
                Console.WriteLine(c);
            }

            Console.ReadKey();
        }

        static void AltaCargo()
        {
            string nombre = PedirPalabras("Ingrese un nombre para el cargo");
            int valorJornal = PedirNumeros("Ingrese el valor de jornal para el cargo");
            Cargo miCargo = new Cargo(nombre, valorJornal);

            try
            {
                sistema.AltaCargo(miCargo);
                MostrarExito("Alta de cargo exitosa");
            }
            catch(Exception ex)
            {
                MostrarError(ex.Message);
            }

            Console.ReadKey();
        }
    }
}