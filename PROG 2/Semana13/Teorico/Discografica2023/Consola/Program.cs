﻿using Dominio;

namespace Consola
{
    internal class Program
    {
        private static Sistema sistema = Sistema.Instancia;

        static void Main(string[] args)
        {
            int opcion = int.MinValue;
            do
            {
                MostrarTitulo("Menu de opciones");
                MostrarMenu();
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        AgregarCancionADisco();
                        break;
                    case 2:
                        ListarDiscosConMayorDuracionQue();
                        break;
                    case 3:
                        MostrarMusicosPorPais();
                        break;
                    case 4:
                        MostrarTodosLosMusicos();
                        break;
                    case 5:
                        AltaDisco();
                        break;
                    case 6:
                        AltaBanda();
                        break;
                    case 7:
                        DiscosMayorPrecioQue();
                        break;
                    case 8:
                        DiscosConCancion();
                        break;
                    case 9:
                        DiscosMayorDuracion();
                        break;
                    case 10:
                        MusicosSinDiscos();
                        break;
                    case 0:
                        MostrarMensaje("Saliendo...");
                        break;
                    default:
                        MostrarError("Debe seleccionar una opcion valida");
                        break;
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            MostrarMensaje("Ingrese una opcion");
            MostrarMensaje("1 - Agregar cancion a disco");
            MostrarMensaje("2 - Mostrar discos con duracion mayor que...");
            MostrarMensaje("3 - Mostrar musicos por pais");
            MostrarMensaje("4 - Mostrar todos los musicos");
            MostrarMensaje("5 - Alta Disco");
            MostrarMensaje("6 - Alta Banda");
            MostrarMensaje("7 - Discos mayor precio que... ordenados precio desc");
            MostrarMensaje("8 - Discos en los cuales esta una cancion");
            MostrarMensaje("9 - El o los discos de mayor duracion");
            MostrarMensaje("10 - El o los musicos que no tienen discos");

        }

        static void MostrarTitulo(string titulo)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.WriteLine($"**** {titulo}  ****");
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        static void MostrarSeparador()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }

        static void MostrarError(string error)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"**** {error}  ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void MostrarExito(string exito)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"**** {exito}  ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        static string PedirPalabras(string mensaje)
        {
            MostrarMensaje(mensaje);
            return Console.ReadLine();
        }

        static int PedirNumeros(string mensaje)
        {
            int numero;
            bool exito = false;
            do
            {
                MostrarMensaje(mensaje);
                exito = int.TryParse(Console.ReadLine(), out numero);
                if (!exito)
                {
                    MostrarError("Debe ingresar solo numeros");
                }
            } while (!exito);

            return numero;
        }

        static Sexo PedirSexo()
        {
            bool exito;
            Sexo sexo = Sexo.Masculino;
            do
            {
                int numero = PedirNumeros("Ingrese sexo \n-> 1 - Masculino\n-> 2 - Femenino");
                switch (numero)
                {
                    case 1:
                        sexo = Sexo.Masculino;
                        exito = true;
                        break;
                    case 2:
                        sexo = Sexo.Femenino;
                        exito = true;
                        break;
                    default:
                        exito = false;
                        break;
                }

                if (!exito)
                {
                    MostrarError("Debe ingresar un numero correspondiente a un sexo");
                }

            } while (!exito);

            return sexo;
        }

        private static void MostrarTodosLosMusicos()
        {
            try
            {
                List<Musico> lista = sistema.Musicos;
                if (lista.Count == 0) throw new Exception("No existen musicos en el sistema");
                MostrarExito("Musicos encontrados");
                foreach (Musico m in lista)
                {
                    Console.WriteLine(m);
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private static void AgregarCancionADisco()
        {
            try
            {
                int codigoCancion = PedirNumeros("Ingrese codigo de cancion");
                string codigoDisco = PedirPalabras("Ingrese codigo de disco");
                int posicion = PedirNumeros("Ingrese la posicion para poner la cancion");

                Disco d = sistema.ObtenerDiscoPorCodigo(codigoDisco);
                Cancion c = sistema.ObtenerCancionPorCodigo(codigoCancion);

                if (d == null) throw new Exception("No se encontro el disco");
                if (c == null) throw new Exception("No se encontro la cancion");

                PosicionCancion pc = new PosicionCancion(posicion, c);
                sistema.AgregarCancionADisco(d, pc);

                MostrarExito("Cancion agregada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void AltaDisco()
        {
            Console.Clear();
            Console.WriteLine("Alta disco");
            Console.WriteLine();

            string titulo = PedirPalabras("Ingrese titulo del disco");
            string codigo = PedirPalabras("Ingrese codigo");
            int anio = PedirNumeros("Ingrese año");
            string nombreAutor = PedirPalabras("Ingrese nombre del autor");

            try
            {
                //Validar datos no nulos
                Musico m = sistema.ObtenerMusicoPorNombre(nombreAutor);
                if (m == null) throw new Exception("No se encontro un musico con ese nombre");
                Disco d = new Disco(codigo, m, titulo, anio);
                sistema.AltaDisco(d);
                MostrarExito("Disco dado de alta");
            }
            catch(Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void ListarDiscosConMayorDuracionQue()
        {
            Console.Clear();
            Console.WriteLine("Discos con mayor duracion que..");
            Console.WriteLine();

            int duracion = PedirNumeros("Ingrese duracion");
            List<Disco> lista = sistema.DiscosConDuracionMayorQue(duracion);
            if (lista.Count == 0)
            {
                MostrarError("No se encontraron resultados");
            }
            else
            {
                foreach (Disco d in lista)
                {
                    Console.WriteLine(d);
                }
            }
        }

        static void MostrarMusicosPorPais()
        {
            Console.Clear();
            Console.WriteLine("Musicos por pais");
            Console.WriteLine();

            string pais = PedirPalabras("Ingrese pais");
            List<Musico> lista = sistema.MusicosPorPais(pais);
            if (lista.Count == 0)
            {
                MostrarError("No se encontraron resultados");
            }
            else
            {
                foreach (Musico m in lista)
                {
                    Console.WriteLine(m);
                }
            }
        }

        static void AltaBanda()
        {
            string nombre = PedirPalabras("Ingrese nombre de la banda");
            string pais = PedirPalabras("Ingrese pais de la banda");
            int integrantes = PedirNumeros("Ingrese cantidad de integrantes");

            try
            {
                //Validar input de usuario antes
                Musico banda = new Banda(nombre, pais, integrantes);
                sistema.AltaMusico(banda);
                MostrarExito("Banda dada de alta");
            }
            catch(Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void DiscosMayorPrecioQue()
        {
            Console.Clear();
            Console.WriteLine("Discos mas caros que..");
            Console.WriteLine();

            int precio = PedirNumeros("Ingrese precio");
            List<Disco> lista = sistema.DiscosMasCarosQue(precio);
            if (lista.Count == 0)
            {
                MostrarError("No se encontraron resultados");
            }
            else
            {
                foreach (Disco d in lista)
                {
                    Console.WriteLine(d);
                }
            }
        }

        static void DiscosConCancion()
        {
            Console.Clear();
            Console.WriteLine("Discos con cancion..");
            Console.WriteLine();

            int codigo = PedirNumeros("Ingrese codigo de cancion");

            try
            {
                List<Disco> lista = sistema.DiscosConCancion(codigo);
                if (lista.Count == 0)
                {
                    MostrarError("No se encontraron resultados");
                }
                else
                {
                    foreach (Disco d in lista)
                    {
                        Console.WriteLine(d);
                    }
                }
            }
            catch (Exception ex)
            {

                MostrarError(ex.Message);
            }
        }

        static void DiscosMayorDuracion()
        {
            Console.Clear();
            Console.WriteLine("Discos mayor duracion..");
            Console.WriteLine();

            List<Disco> lista = sistema.DiscosConMayorDuracion();
            if (lista.Count == 0)
            {
                MostrarError("No se encontraron resultados");
            }
            else
            {
                foreach (Disco d in lista)
                {
                    Console.WriteLine(d);
                }
            }

            Console.ReadKey();
        }

        static void MusicosSinDiscos()
        {
            Console.Clear();
            Console.WriteLine("Musicos sin discos..");
            Console.WriteLine();

            List<Musico> lista = sistema.MusicosSinDiscos();
            if (lista.Count == 0)
            {
                MostrarError("No se encontraron resultados");
            }
            else
            {
                foreach (Musico m in lista)
                {
                    Console.WriteLine(m);
                }
            }

            Console.ReadKey();
        }
    }
}