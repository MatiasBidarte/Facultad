using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practico3;

class Program
{
    static void Main(string[] args)
    {
        bool salir = false;
        string opcion = string.Empty;

        while (!salir)
        {
            Console.Clear();
            MostrarMenu();
            opcion = PedirPalabras("Ingrese una opcion");

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Ejercicio1();
                    break;
                case "2":
                    Console.Clear();
                    Ejercicio2();
                    break;
                case "3":
                    Console.Clear();
                    Ejercicio3();
                    break;
                case "0":
                    Console.WriteLine("Saliendo ... ");
                    salir = true;
                    Console.ReadKey();
                    break;
                default:
                    MostrarError("Opcion incorrecta");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static string PedirPalabras(string mensaje)
    {
        Console.WriteLine(mensaje);
        return Console.ReadLine();
    }

    static void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    static void MostrarError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    static void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    static void MostrarMenu()
    {
        Console.WriteLine(" --- MENU --- ");
        Console.WriteLine("1 - Ejercicio 1");
        Console.WriteLine("2 - Ejercicio 2");
        Console.WriteLine("3 - Ejercicio 3");
        Console.WriteLine("0 - Salir");
        Console.WriteLine();
    }

    static int PedirNumeros(string mensaje)
    {
        bool exito = false;
        int numero = 0;

        while (!exito)
        {
            Console.WriteLine(mensaje);
            exito = int.TryParse(Console.ReadLine(), out numero);

            if (!exito)
            {
                MostrarError("Error: Solo se admiten numeros enteros");
                Console.WriteLine();
            }
        }
        return numero;
    }

    static void ComparadorNumerosEntre1y10(int numero)
    {
        if (numero >= 1 && numero <= 10)
        {
            Random generador = new Random();
            int aleatorio = generador.Next(1, 11);
            if (numero == aleatorio)
            {
                MostrarExito($"el numero {numero} y el numero {aleatorio} son iguales");
            }
            else
            {
                MostrarMensaje($"el numero {numero} y el numero {aleatorio} NO son iguales");
            }
        }
        else
        {
            MostrarError("el numero no esta entre 1 y 10");
        }
    }

    static void Ejercicio1()
    {
        bool salir = false;

        while (!salir)
        {
            int numero = PedirNumeros("Ingresa un numero entre 1 y 10, o 0 si queres detener el programa");
            Console.WriteLine();
            if (numero == 0)
            {
                salir = true;
            }
            else
            {
                ComparadorNumerosEntre1y10(numero);
            }
        }
    }

    static void MultiplicadorHasta10 (int numero)
    {
        MostrarMensaje($"Tabla del {numero}: ");
        Console.WriteLine();
        for (int i = 1; i <= 10; i++)
        {
            MostrarMensaje($"{numero} x {i} = {numero * i}");
        }
        Console.WriteLine("");
    }

    static void Ejercicio2()
    {
        bool salir = false;

        while (!salir)
        {
            int numero = PedirNumeros("Ingresa un numero entre 1 y 10, o 0 si queres detener el programa");
            if (numero == 0)
            {
                salir = true;
            }
            else
            {
                MultiplicadorHasta10(numero);
            }
        }
    }

    static void Ejercicio3()
    {
        bool salir = false;
        while (!salir)
        {
            int num1 = PedirNumeros("ingrese numero 1");
            int num2 = PedirNumeros("ingrese numero 2");

            if (num1 == 0 || num2 == 0)
            {
                salir = true;
            }
            else
            {
                if (num1 > num2)
                {
                    (num2, num1) = (num1, num2);
                }
                MostrarMensaje($"los numeros pares entre {num1} y {num2} son: ");
                 for(int i = num1; i <= num2; i++)
                 {
                    if (i % 2 == 0)
                    {
                        MostrarMensaje($"{i}");
                    }
                 }
            }
        }
    }
}

