namespace Ejercicio_4;

class Program
{
    static void Main(string[] args)
    {
        Cuenta miCuenta = new Cuenta("matias", "CC", "U$D");
        Console.WriteLine(miCuenta);
        bool exito = miCuenta.Deposito(1500, "$");
        Console.WriteLine(exito);
        Console.WriteLine(miCuenta);
        bool exito1 = miCuenta.Retiro(400, "$");
        Console.WriteLine(exito1);
        Console.WriteLine(miCuenta);
        bool exito2 = miCuenta.Retiro(400, "U$D");
        Console.WriteLine(exito2);
        Console.WriteLine(miCuenta);
        bool exito3 = miCuenta.Deposito(1000000, "U$D");
        Console.WriteLine(exito3);
        Console.WriteLine(miCuenta);
        bool exito4 = miCuenta.Deposito(100, "U$D");
        Console.WriteLine(exito4);
        Console.WriteLine(miCuenta);
        Console.ReadKey();
    }
}

