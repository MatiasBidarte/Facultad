namespace Ejercicio2;

class Program
{
    static void Main(string[] args)
    {
        Empleado miEmpleado = new Empleado("matias", "bidarte", "11-08-2001", 3.2, 7, 79);
        Console.WriteLine($"mi salario es {miEmpleado.CalcularSalario()}");
        Console.WriteLine($"tengo {miEmpleado.CalcularLicencia()} dias de licencia");
        Console.WriteLine(miEmpleado);
        Console.ReadKey();
    }
}

