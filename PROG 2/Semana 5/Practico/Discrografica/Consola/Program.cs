using Dominio;

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
                        AltaDisco();
                        break;
                    case "2":
                        MostrarAutores();
                        break;
                    case "3":
                        MostrarCanciones();
                        break;
                    case "4":
                        MostrarDiscos();
                        break;
                    case "5":
                        MostrarDiscosPorDuracion();
                        break;
                    case "6":
                        MostrarAutoresPorPais();
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
            Console.WriteLine("1 - Alta Disco");
            Console.WriteLine("2 - Mostrar autores");
            Console.WriteLine("3 - Mostrar canciones");
            Console.WriteLine("4 - Mostrar discos");
            Console.WriteLine("5 - Mostrar discos por duracion");
            Console.WriteLine("6 - Mostrar autores por pais");
            Console.WriteLine("0 - Salir");
        }

        static void AltaDisco()
        {
            Console.Clear();
            string nombreAutor = PedirPalabras("Ingrese el nombre del autor");
            string titulo = PedirPalabras("Ingrese el titulo del disco");
            int codigo = PedirNumeros("Ingrese el codigo del disco");
            int anio = PedirNumeros("Ingrese el año del disco");
            MostrarAutores();
            try
            {
                //validaciones con if - throw de los datos de entrada
                Autor autor = sistema.BuscarAutor(nombreAutor);
                string salida = null;
                List<PosCancion> canciones = new List<PosCancion>();
                MostrarCanciones();
                while (salida != "0")
                {
                    string nombreCancion = PedirPalabras("Ingrese el nombre de la cancion, si quiere dejar de agregar, presione 0");
                    if (nombreCancion != "0")
                    {
                        Cancion cancion = sistema.BuscarCancion(nombreCancion);
                        int posicion = PedirNumeros("Ingrese la posicion de la cancion en el disco");
                        PosCancion posCancion = new PosCancion(cancion, posicion);
                        posCancion.Validar();
                        canciones.Add(posCancion);
                    }
                    else salida = "0";
                }
                sistema.AltaDisco(new Disco(autor, titulo, anio, canciones, codigo));
                MostrarExito("Disco agregado correctamente");
                Console.ReadKey();

            } catch(Exception ex)
            {
                MostrarError(ex.Message);
                Console.ReadKey();
            }
        }

        static void MostrarAutores()
        {
            Console.Clear();
            foreach(Autor a in sistema.Autores)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }

        static void MostrarCanciones()
        {
            Console.Clear();
            foreach(Cancion c in sistema.Canciones)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();
        }

        static void MostrarDiscos()
        {
            Console.Clear();
            foreach(Disco c in sistema.Discos)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();
        }

        static void MostrarDiscosPorDuracion()
        {
            Console.Clear();
            int minutos = PedirNumeros("Ingrese la cantidad de minutos");
            List<Disco> discos = sistema.ObtenerDiscosPorMinutos(minutos);
            if (discos.Count == 0) MostrarError("No hay discos con mas duracion que la dada");
            foreach(Disco disco in discos)
            {
                Console.WriteLine(disco);
            }
            Console.ReadKey();
        }

        static void MostrarAutoresPorPais()
        {
            Console.Clear();
            string pais = PedirPalabras("Ingrese el pais a buscar");
            List<Autor> autores = sistema.ObtenerAutoresPorPais(pais);
            if (autores.Count == 0) MostrarError("No hay autores con el pais dado");
            foreach(Autor autor in autores)
            {
                Console.WriteLine(autor);
            }
            Console.ReadKey();
        }
    }
}