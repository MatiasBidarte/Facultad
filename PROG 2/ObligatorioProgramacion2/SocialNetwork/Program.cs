using Dominio;
namespace Consola;


class Program
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
                    AltaMiembro();
                    break;
                case "2":
                    ListarPublicaciones();
                    break;
                case "3":
                    ListarPublicacionesConComentario();
                    break;
                case "4":
                    ListarPostPorFecha();
                    break;
                case "5":
                    ListarMayoresPublicadores();
                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "8":

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
        Console.WriteLine();
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

    static DateTime PedirFecha(string mensaje)
    {
        bool exito = false;
        DateTime fecha = DateTime.Now;

        while (!exito)
        {
            Console.WriteLine();
            Console.WriteLine(mensaje);
            exito = DateTime.TryParse(Console.ReadLine(), out fecha);
            if (!exito)
            {
                MostrarError("Debe ingresar una fecha valida");
            }
        }
        return fecha;
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine(" ---- MENU ----");
        Console.WriteLine("1 - Alta miembro");
        Console.WriteLine("2 - Listar publicaciones de un usuario");
        Console.WriteLine("3 - Listar publiaciones por comentario de usuario");
        Console.WriteLine("4 - Listar publiaciones entre fechas");
        Console.WriteLine("5 - Listar miembros con mayor cantidad de publicaciones");
        Console.WriteLine("0 - Salir");
    }

    static void AltaMiembro()
    {
        Console.Clear();

        string mail = PedirPalabras("Ingrese el mail");
        string contra = PedirPalabras("Ingrese su contraseña");
        string nombre = PedirPalabras("Ingrese su nombre");
        string apellido = PedirPalabras("Ingrese su apellido");
        DateTime fechaNacimiento = PedirFecha("Ingrese su fecha de nacimiento en formato dd/mm/aaaa");

        try
        {
            if (string.IsNullOrEmpty(mail)) throw new Exception("el mail no puede ser nulo");
            if (string.IsNullOrEmpty(contra)) throw new Exception("la contraseña no puede ser nula");
            if (string.IsNullOrEmpty(nombre)) throw new Exception("el nombre no puede ser nulo");
            if (string.IsNullOrEmpty(apellido)) throw new Exception("el apellido no puede ser nulo");

            Miembro miembro = new Miembro(mail, contra, nombre, apellido, fechaNacimiento);
            sistema.AltaUsuario(miembro);

            MostrarExito("Miembro agregado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }

    static void ListarPublicaciones()
    {
        Console.Clear();
        string mail = PedirPalabras("Ingrese el mail a buscar las publicaciones");
        Console.WriteLine();

        try
        {
            if (string.IsNullOrEmpty(mail)) throw new Exception("no se puede ingresar un mail nulo");
            List<Publicacion> publicaciones = sistema.ObtenerPublicacionesDeMiembro(mail);

            if (publicaciones.Count == 0) MostrarExito("El usuario no tiene publicaciones");
            else
            {
                foreach (Publicacion p in publicaciones)
                {
                    Console.WriteLine(p);
                    Console.WriteLine();
                    Console.WriteLine("--------------");
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }
        Console.ReadKey();
    }

    static void ListarPublicacionesConComentario()
    {
        Console.Clear();
        Console.WriteLine("Listado de posts con comentarios hechos por el usuario");
        string email = PedirPalabras("Ingrese el email a buscar");
        Console.WriteLine();

        try
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("no se puede ingresar un mail nulo");
            List<Post> publicaciones = sistema.ObtenerPublicacionesConComentario(email);

            if (publicaciones.Count == 0) MostrarExito("El usuario no tiene comentarios en ningun post");
            else
            {
                foreach (Post post in publicaciones)
                {
                    Console.WriteLine(post);
                    Console.WriteLine();
                    Console.WriteLine("---------------");
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }
        Console.ReadKey();
    }

    static void ListarPostPorFecha()
    {
        Console.Clear();
        Console.WriteLine("Listado de posts por fecha");

        DateTime fecha1 = PedirFecha("Ingrese la primer fecha en formato dd/mm/aaaa");
        DateTime fecha2 = PedirFecha("Ingrese la segunda fecha en formato dd/mm/aaaa");

        try
        {
            sistema.CambiarLongitudDeTextoDePosts();
            List<Post> posts = sistema.ListarPostsPorFecha(fecha1, fecha2);

            if (posts.Count == 0) MostrarExito("No hay ninguna publicacion entre dichas fechas");
            else
            {
                foreach (Post p in posts)
                {
                    Console.WriteLine(p);
                    Console.WriteLine();
                }
            }


            sistema.CambiarLongitudDeTextoDePosts();

        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }

        Console.ReadKey();
    }

    static void ListarMayoresPublicadores()
    {
        Console.Clear();
        Console.WriteLine("Listado de los mayores publicadores");

        try
        {
            List<Miembro> miembrosConMayoresPublis = sistema.ObtenerMiembrosConMayoresPublicaciones();

            if (miembrosConMayoresPublis.Count == 0) MostrarExito("Ningun usuario realizo publicaciones");
            else
            {
                foreach (Miembro m in miembrosConMayoresPublis)
                {
                    Console.WriteLine(m);
                    Console.WriteLine();
                }
            }
        }
        catch (Exception e)
        {
            MostrarError(e.Message);
        }

        Console.ReadKey();
    }
}

