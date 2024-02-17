using System;
namespace Dominio
{
    public class Comentario : Publicacion
    {

        public Comentario(string titulo, DateTime fechaCreacion, Miembro creador, Privacidad privacidad, string texto, string contenido) : base(titulo, fechaCreacion, creador, privacidad, texto, contenido)
        {
        }

        public override string Tipo()
        {
            return "Comentario";
        }

        /*Cuando se quiera mostrar un comentario, tambien se mostraran las reacciones en el*/
        public override string ToString()
        {
            string retorno = $"Tipo: Comentario - Id: {_id} - Titulo: {_titulo} - Creador: {_creador} - Privacidad: {_privacidad}";
            if (_reacciones.Count != 0)
            {
                retorno += "\n  Reacciones en el comentario:";
                foreach (Reaccion r in _reacciones)
                {
                    retorno += $"\n    {r}";
                }
            }
            return retorno;
        }
    }
}