using System;
namespace Dominio.Excepciones.Auto
{
    public class MatriculaInvalidaException : AutoInvalidoException
    {
        public MatriculaInvalidaException() { }
        public MatriculaInvalidaException(string message) : base(message) { }
    }
}

