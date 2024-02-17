namespace Ejercicio1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Cliente cliente1 = new Cliente("51263152", "Matias", new CuentaCorriente(123123, TipoMoneda.UYU));
            cliente1.Validar();

            cliente1.Depositar(300, TipoMoneda.UYU);
            cliente1.Retirar(150, TipoMoneda.UYU);

            Console.WriteLine(cliente1);

        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}

