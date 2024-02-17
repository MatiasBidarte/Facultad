using Dominio;
using System;
using System.Collections.Generic;


namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _listaUsuarios = new List<Usuario>();
        private List<Invitacion> _listaInvitaciones = new List<Invitacion>();
        private List<Publicacion> _listaPublicaciones = new List<Publicacion>();
        #region Singleton

        private static Sistema _instancia;

        private Sistema()
        {
            PrecargarUsuarios();
            PrecargaInvitaciones();
            PrecargaPublicaciones();

        }

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }

        #endregion

        #region Properties
        public List<Invitacion> Invitaciones
        {
            get { return _listaInvitaciones; }
        }

        public List<Usuario> Usuarios
        {
            get { return _listaUsuarios; }
        }

        public List<Publicacion> Publicaciones
        {
            get { return _listaPublicaciones; }
        }
        #endregion

        private void PrecargarUsuarios()
        {
            AltaUsuario(new Miembro("emi@gmail.com", "123", "emiliano", "ferreira", new DateTime(2002, 1, 4)));
            AltaUsuario(new Miembro("nicolas.buffa@gmail.com", "contraseña2", "nicolas", "buffa", new DateTime(2002, 10, 1)));
            AltaUsuario(new Miembro("pepe@gmail.com", "123", "pepe", "Gomez", new DateTime(1980, 12, 12)));
            AltaUsuario(new Miembro("roberto.lol@gmail.com", "contraseña4", "roberto", "llores", new DateTime(2010, 10, 10)));
            AltaUsuario(new Miembro("luisa.robb@gmail.com", "contraseña5", "luisa", "robb", new DateTime(2000, 8, 14)));
            AltaUsuario(new Miembro("lore.progamer@gmail.com", "contraseña6", "lore", "rodriguez", new DateTime(2005, 5, 16)));
            AltaUsuario(new Miembro("lucrecia.robot@gmail.com", "contraseña7", "lucrecia", "lorenza", new DateTime(2007, 6, 19)));
            AltaUsuario(new Miembro("lola.manyaxsiempre@gmail.com", "contraseña8", "lola", "gonzalez", new DateTime(2002, 4, 23)));
            AltaUsuario(new Miembro("lolo@gmail.com", "123", "lolo", "jimenez", new DateTime(1999, 7, 14)));
            AltaUsuario(new Miembro("jose@gmail.com", "123", "jose", "gomez", new DateTime(1998, 6, 24)));
            AltaUsuario(new Miembro("block@gmail.com", "123", "block", "gomez", new DateTime(1998, 6, 24), true));
            AltaUsuario(new Administrador("maty@gmail.com", "123"));
        }
        private void PrecargaInvitaciones()
        {
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("pepe@gmail.com"), ObtenerMiembroPorEmail("roberto.lol@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("luisa.robb@gmail.com"), ObtenerMiembroPorEmail("lore.progamer@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("lucrecia.robot@gmail.com"), ObtenerMiembroPorEmail("lola.manyaxsiempre@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("jose@gmail.com"), ObtenerMiembroPorEmail("lolo@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("pepe@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("roberto.lol@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("luisa.robb@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("lore.progamer@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("lucrecia.robot@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("lola.manyaxsiempre@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("lolo@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("emi@gmail.com"), ObtenerMiembroPorEmail("jose@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("pepe@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("roberto.lol@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("luisa.robb@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("lore.progamer@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("lucrecia.robot@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("lola.manyaxsiempre@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("lolo@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("jose@gmail.com")));
            AltaSolicitud(new Invitacion(ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), ObtenerMiembroPorEmail("emi@gmail.com")));

            /*Se aceptan o rechazan las invitaciones creadas arriba*/
            AceptarInvitacion(1, "roberto.lol@gmail.com");
            AceptarInvitacion(2, "lore.progamer@gmail.com");
            RechazarInvitacion(3, "lola.manyaxsiempre@gmail.com");

            /*Invitaciones para el usuario de nicolas*/
            AceptarInvitacion(5, "pepe@gmail.com");
            AceptarInvitacion(6, "roberto.lol@gmail.com");
            AceptarInvitacion(7, "luisa.robb@gmail.com");
            AceptarInvitacion(8, "lore.progamer@gmail.com");
            AceptarInvitacion(9, "lucrecia.robot@gmail.com");
            AceptarInvitacion(10, "lola.manyaxsiempre@gmail.com");
            AceptarInvitacion(11, "lolo@gmail.com");
            AceptarInvitacion(12, "jose@gmail.com");

            /*Invitaciones para el usuario de emiliano*/
            AceptarInvitacion(13, "pepe@gmail.com");
            AceptarInvitacion(14, "roberto.lol@gmail.com");
            AceptarInvitacion(15, "luisa.robb@gmail.com");
            AceptarInvitacion(16, "lore.progamer@gmail.com");
            AceptarInvitacion(17, "lucrecia.robot@gmail.com");
            AceptarInvitacion(18, "lola.manyaxsiempre@gmail.com");
            AceptarInvitacion(19, "lolo@gmail.com");
            AceptarInvitacion(20, "jose@gmail.com");

            /*Invitacion entre ambos*/
            AceptarInvitacion(21, "emi@gmail.com");
        }

        private void PrecargaPublicaciones()
        {
            AltaComentario(new Comentario("comentario1", DateTime.Now, ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), Privacidad.Publico, "Maldivas", "Que bellas islas!"));
            AltaComentario(new Comentario("comentario2", DateTime.Now, ObtenerMiembroPorEmail("pepe@gmail.com"), Privacidad.Publico, "Felicidades", "Felicidades por el viaje"));
            AltaComentario(new Comentario("comentario3", DateTime.Now, ObtenerMiembroPorEmail("luisa.robb@gmail.com"), Privacidad.Publico, "Alegria", "A ver cuando nos vemos!"));
            AltaComentario(new Comentario("comentario1", DateTime.Now, ObtenerMiembroPorEmail("pepe@gmail.com"), Privacidad.Privado, "Es rico", "el mejor pan del uruguay"));
            AltaComentario(new Comentario("comentario2", DateTime.Now, ObtenerMiembroPorEmail("roberto.lol@gmail.com"), Privacidad.Privado, "No me gusta", "No me gusta el pan flauta, es feo"));
            AltaComentario(new Comentario("comentario3", DateTime.Now, ObtenerMiembroPorEmail("jose@gmail.com"), Privacidad.Privado, "Prefiero otro", "Me gusta la flauta, pero prefiero el pan de molde"));
            AltaComentario(new Comentario("comentario1", DateTime.Now, ObtenerMiembroPorEmail("emi@gmail.com"), Privacidad.Publico, "Hermoso perro", "Me encanta tu perro, es muy lindo"));
            AltaComentario(new Comentario("comentario2", DateTime.Now, ObtenerMiembroPorEmail("lolo@gmail.com"), Privacidad.Publico, "Felicidades", "Felicidades por el perro!"));
            AltaComentario(new Comentario("comentario3", DateTime.Now, ObtenerMiembroPorEmail("lola.manyaxsiempre@gmail.com"), Privacidad.Publico, "No me gusta", "Que feo perro, cambialo por otro"));
            AltaComentario(new Comentario("comentario1", DateTime.Now, ObtenerMiembroPorEmail("lolo@gmail.com"), Privacidad.Publico, "Genial", "Salud!"));
            AltaComentario(new Comentario("comentario2", DateTime.Now, ObtenerMiembroPorEmail("lola.manyaxsiempre@gmail.com"), Privacidad.Publico, "Que delicia", "Me diste hambre"));
            AltaComentario(new Comentario("comentario3", DateTime.Now, ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), Privacidad.Publico, "Invitacion", "A ver cuando invitas"));
            AltaComentario(new Comentario("comentario1", DateTime.Now, ObtenerMiembroPorEmail("emi@gmail.com"), Privacidad.Publico, "Alergia", "Le tengo alergia a los gatos"));
            AltaComentario(new Comentario("comentario2", DateTime.Now, ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), Privacidad.Publico, "Hermoso", "Muy lindo gato"));
            AltaComentario(new Comentario("comentario3", DateTime.Now, ObtenerMiembroPorEmail("roberto.lol@gmail.com"), Privacidad.Publico, "Grande", "Que gato tan grande"));
            AltaComentario(new Comentario("comentario perdido", DateTime.Now, ObtenerMiembroPorEmail("lore.progamer@gmail.com"), Privacidad.Privado, "Privacidad", "Este comentario es solo visible para mi"));

            AltaPost(new Post("posteo en islas maldivas", DateTime.Now, ObtenerMiembroPorEmail("emi@gmail.com"), "IslasMaldivas.jpg", Privacidad.Publico, false, "islas maldivas", "Pasando un hermoso mes en las islas maldivas"));
            AltaPost(new Post("imagen comiendo pan", DateTime.Now, ObtenerMiembroPorEmail("jose@gmail.com"), "flauta.jpeg", Privacidad.Privado, false, "Pan faluta", "Un excelente pan flauta"));
            AltaPost(new Post("foto de mi perro", DateTime.Now, ObtenerMiembroPorEmail("nicolas.buffa@gmail.com"), "fito.jpeg", Privacidad.Publico, false, "fitito", "Mi hermoso perro fito"));
            AltaPost(new Post("foto comiendo", DateTime.Now, ObtenerMiembroPorEmail("lucrecia.robot@gmail.com"), "almuerzo.jpeg", Privacidad.Publico, false, "Almuerzo", "Almorzando saludablemente"));
            AltaPost(new Post("foto de mi gato", DateTime.Now, ObtenerMiembroPorEmail("lore.progamer@gmail.com"), "tino.jpeg", Privacidad.Publico, false, "mi gato tino", "Les vengo a mostrar a mi gato tino"));
            AltaPost(new Post("foto random", new DateTime(2022, 08, 21), ObtenerMiembroPorEmail("lore.progamer@gmail.com"), "random.jpeg", Privacidad.Publico, false, "alguna foto", "Alguna foto de la galeria"));
            AltaPost(new Post("probando metodo", new DateTime(2022, 08, 11), ObtenerMiembroPorEmail("lore.progamer@gmail.com"), "foto.jpeg", Privacidad.Publico, false, "Texto necesario para superar 50 caracteres asi corroboramos que funciona el metodo para acortar strings", "Alguna foto"));
            AltaPost(new Post("foto inapropiada", DateTime.Now, ObtenerMiembroPorEmail("pepe@gmail.com"), "inap.jpeg", Privacidad.Publico, true, "una foto inapropiada", "No se puede ver"));


            /* Se agregan comentarios a los posts como lo requiere la letra */
            AgregarComentarioAPost(17, ObtenerComentarioPorId(1));
            AgregarComentarioAPost(17, ObtenerComentarioPorId(2));
            AgregarComentarioAPost(17, ObtenerComentarioPorId(3));
            AgregarComentarioAPost(18, ObtenerComentarioPorId(4));
            AgregarComentarioAPost(18, ObtenerComentarioPorId(5));
            AgregarComentarioAPost(18, ObtenerComentarioPorId(6));
            AgregarComentarioAPost(19, ObtenerComentarioPorId(7));
            AgregarComentarioAPost(19, ObtenerComentarioPorId(8));
            AgregarComentarioAPost(19, ObtenerComentarioPorId(9));
            AgregarComentarioAPost(20, ObtenerComentarioPorId(10));
            AgregarComentarioAPost(20, ObtenerComentarioPorId(11));
            AgregarComentarioAPost(20, ObtenerComentarioPorId(12));
            AgregarComentarioAPost(21, ObtenerComentarioPorId(13));
            AgregarComentarioAPost(21, ObtenerComentarioPorId(14));
            AgregarComentarioAPost(21, ObtenerComentarioPorId(15));

            /* Se reaccionan publicaciones como indica la letra*/
            ReaccionarPost("emi@gmail.com", TipoReaccion.LIKE, 17);
            ReaccionarPost("nicolas.buffa@gmail.com", TipoReaccion.DISLIKE, 17);
            ReaccionarComentario("nicolas.buffa@gmail.com", TipoReaccion.LIKE, 1);
            ReaccionarComentario("emi@gmail.com", TipoReaccion.DISLIKE, 1);
        }

        public void AltaUsuario(Usuario usuario)
        {
            if (usuario == null) throw new Exception("el usuario no puede ser nulo");
            usuario.Validar();
            if (_listaUsuarios.Contains(usuario)) throw new Exception("El usuario ya esta ingresado");
            _listaUsuarios.Add(usuario);
        }

        public void AltaSolicitud(Invitacion invitacion)
        {
            if (invitacion == null) throw new Exception("La invitacion no puede ser nula");
            invitacion.Validar();
            _listaInvitaciones.Add(invitacion);
        }

        public void AltaPost(Post post)
        {
            if (post == null) throw new Exception("El post no puede ser nulo");
            post.Validar();
            _listaPublicaciones.Add(post);
        }

        public void AltaComentario(Comentario comentario)
        {
            if (comentario == null) throw new Exception("El comentario no puede ser nulo");
            comentario.Validar();
            _listaPublicaciones.Add(comentario);
        }

        public Usuario Login (string email, string contra)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("email vacio, revise");
            if (string.IsNullOrEmpty(contra)) throw new Exception("contraseña vacia, revise");

            Usuario u = null;
            int i = 0;
            while (u == null && i < _listaUsuarios.Count)
            {
                if (_listaUsuarios[i].Email == email && _listaUsuarios[i].Contrasenia== contra) u = _listaUsuarios[i];
                i++;
            }
            return u;
        }

        public void BloquearMiembro(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("El email no puede ser vacio");
            Miembro m = ObtenerMiembroPorEmail(email);

            if (m == null) throw new Exception("Miembro a bloquear no encontrado");

            m.Bloquear();
        }

        public void DesbloquearMiembro(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("El email no puede ser vacio");
            Miembro m = ObtenerMiembroPorEmail(email);

            if (m == null) throw new Exception("Miembro a desbloquear no encontrado");

            m.Desbloquear();
        }

        public void CensurarPost(int id)
        {
            Post p = ObtenerPostPorId(id) ?? throw new Exception("Post a censurar no encontrado");
            p.Censurar();
        }

        public void QuitarCensuraPost(int id)
        {
            Post p = ObtenerPostPorId(id) ?? throw new Exception("Post a quitar censura no encontrado");
            p.QuitarCensura();
        }

        private void ValidarInvitacionNoExiste(Invitacion inv)
        {
            foreach (Invitacion i in _listaInvitaciones )
            {
                if ((i.MiembroSolicitante.Equals(inv.MiembroSolicitante) && i.MiembroSolicitado.Equals(inv.MiembroSolicitado))||
                    i.MiembroSolicitante.Equals(inv.MiembroSolicitado) && i.MiembroSolicitado.Equals(inv.MiembroSolicitante))
                {
                    throw new Exception("Ya hay una solicitud ingresada en el sistema");
                }
            }
        }

        public void SolicitarAmistad(Miembro solicitante, Miembro solicitado)
        {
            if (solicitante == null) throw new Exception("El miembro solicitantte no puede ser nulo");
            if (solicitado == null) throw new Exception("El miembro solicitado no puede ser nulo");

            if (!solicitante.EsAmigo(solicitado) && !solicitado.EsAmigo(solicitante))
            {
                Invitacion inv = new Invitacion(solicitante, solicitado);
                ValidarInvitacionNoExiste(inv);
                AltaSolicitud(inv);
            }
        }

        public void AceptarInvitacion(int idInvitacion, string emailMiembroSolicitado)
        {
            Invitacion i = ObtenerInvitacionPorId(idInvitacion);
            Miembro m = ObtenerMiembroPorEmail(emailMiembroSolicitado);

            if (i == null) throw new Exception("No existe la invitacion solicitada");
            if (m == null) throw new Exception("El miembro solicitado no existe");

            i.AceptarInvitacion(m);
        }

        public void RechazarInvitacion(int idInvitacion, string emailMiembroSolicitado)
        {
            Invitacion i = ObtenerInvitacionPorId(idInvitacion);
            Miembro m = ObtenerMiembroPorEmail(emailMiembroSolicitado);

            if (i == null) throw new Exception("No existe la invitacion solicitada");
            if (m == null) throw new Exception("El miembro solicitado no existe");

            i.RechazarInvitacion();
        }

        public List<Invitacion> ObtenerInvitacionesPorEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("El mail no puede ser nulo");
            Miembro m = ObtenerMiembroPorEmail(email);
            List<Invitacion> invitaciones = new List<Invitacion>();

            foreach (Invitacion i in _listaInvitaciones)
            {
                if (i.MiembroSolicitado.Equals(m)) invitaciones.Add(i);
            }
            return invitaciones;
        }

        private Invitacion ObtenerInvitacionPorId(int id)
        {
            Invitacion buscado = null;
            int i = 0;
            while (buscado == null && i < _listaInvitaciones.Count)
            {
                if (_listaInvitaciones[i].ID == id) buscado = _listaInvitaciones[i];
                i++;
            }
            return buscado;
        }

        public List<Publicacion> ObtenerPublicacionesDeMiembro(string email)
        {
            List<Publicacion> retorno = new List<Publicacion>();
            Usuario user = ObtenerMiembroPorEmail(email);
            if (user == null) throw new Exception("No existe el usuario en nuestro sistema");
            Miembro m = user as Miembro;

            foreach (Publicacion p in _listaPublicaciones)
            {
                if (p is Post)
                {
                    Post pAux = p as Post;
                    if (!pAux.EstaCensurado && p.Creador.Equals(m)) retorno.Add(pAux);
                }
                else if (p.Creador.Equals(m)) retorno.Add(p);
            }
            return retorno;
        }

        public List<Post> ObtenerPublicacionesConComentario(string email)
        {
            List<Post> retorno = new List<Post>();
            Usuario user = ObtenerMiembroPorEmail(email);
            if (user == null) throw new Exception("No existe el usuario en nuestro sistema");
            Miembro m = user as Miembro;
            List<Post> listaPost = new List<Post>();

            /*Primero guardo una lista de Posts, y luego consulto si el usuario hizo comentarios en dichos posts*/
            foreach (Publicacion p in _listaPublicaciones)
            {
                if (p is Post) listaPost.Add(p as Post);
            }

            foreach (Post p in listaPost)
            {
                foreach (Comentario c in p.Comentarios)
                {
                    if (c.Creador.Equals(m)) retorno.Add(p);
                }
            }

            return retorno;
        }

        public List<Post> ObtenerPostsParaMiembro(string email)
        {
            Miembro m = ObtenerMiembroPorEmail(email) ?? throw new Exception("Usuario no encontrado");
            List<Post> posts = new List<Post>();
            foreach (Publicacion p in _listaPublicaciones)
            {
                if (p is Post)
                {
                    Post pAux = p as Post;
                    if (pAux.EstaCensurado == false)
                    {
                        if (pAux.Privacidad == Privacidad.Publico || pAux.Creador.Equals(m) || m.EsAmigo(pAux.Creador))
                        {
                            posts.Add(pAux);
                        }
                    }
                }
            }
            return posts;
        }

        public void AgregarComentarioAPost(int idPost, Comentario c)
        {
            Post post = ObtenerPostPorId(idPost);
            if (post == null) throw new Exception("No existe el post con dicho Id");
            if (post.EstaCensurado) throw new Exception("No se puede comentar un post censurado");
            if (post.Privacidad == Privacidad.Publico && c.Privacidad == Privacidad.Privado) throw new Exception("No se puede hacer un comentario privado en un post publico");
            if (post.Privacidad == Privacidad.Privado && c.Privacidad == Privacidad.Publico) throw new Exception("No se puede hacer un comentario publico en un post privado");
            c.Validar();
            post.AgregarComentario(c);
        }

        public void ReaccionarPost(string email, TipoReaccion tipoReaccion, int idPost)
        {
            Miembro m = ObtenerMiembroPorEmail(email);
            Post post = ObtenerPostPorId(idPost);
            if (post == null) throw new Exception("No existe el post con dicho Id");
            if (post.EstaCensurado) throw new Exception("No se puede reaccionar un post censurado");
            if (m == null) throw new Exception("El miembro no existe");
            ValidarPublicacionNoReaccionadaPorMiembro(post, m); /*Metodo que verifica que el usuario m no haya reaccionado al post*/
            Reaccion reaccion = new Reaccion(tipoReaccion, m);
            reaccion.Validar();
            post.Reacciones.Add(reaccion);
        }

        public void ReaccionarComentario(string email, TipoReaccion tipoReaccion, int idComentario)
        {
            Miembro m = ObtenerMiembroPorEmail(email);
            Comentario c = ObtenerComentarioPorId(idComentario);
            if (c == null) throw new Exception("No existe el comentario con dicho Id");
            if (m == null) throw new Exception("El miembro no existe");
            ValidarPublicacionNoReaccionadaPorMiembro(c, m);
            Reaccion reaccion = new Reaccion(tipoReaccion, m);
            c.Reacciones.Add(reaccion);
        }

        private void ValidarPublicacionNoReaccionadaPorMiembro(Publicacion p, Miembro m)
        {
            int i = 0;

            while (i < p.Reacciones.Count)
            {
                if (p.Reacciones[i].Creador.Equals(m)) throw new Exception("El usuario ya ha reaccionado a esta publicacion");
                i++;
            }
        }

        private Post ObtenerPostPorId(int id)
        {
            Post buscado = null;
            int i = 0;

            while (i < _listaPublicaciones.Count && buscado == null)
            {
                if (_listaPublicaciones[i].Id.Equals(id) && _listaPublicaciones[i] is Post) buscado = _listaPublicaciones[i] as Post;
                i++;
            }
            return buscado;
        }

        private Comentario ObtenerComentarioPorId(int id)
        {
            Comentario buscado = null;
            int i = 0;

            while (i < _listaPublicaciones.Count && buscado == null)
            {
                if (_listaPublicaciones[i].Id.Equals(id) && _listaPublicaciones[i] is Comentario) buscado = _listaPublicaciones[i] as Comentario;
                i++;
            }
            return buscado;
        }

        public Miembro ObtenerMiembroPorEmail(string mail)
        {
            Miembro buscado = null;

            int i = 0;

            while (buscado == null && i < _listaUsuarios.Count)
            {
                if (_listaUsuarios[i].Email.Equals(mail) && _listaUsuarios[i] is Miembro)
                {
                    Miembro miembroAuxiliar = _listaUsuarios[i] as Miembro;
                    buscado = miembroAuxiliar;
                };
                i++;
            }

            return buscado;
        }

        public List<Miembro> ObtenerMiembrosOrdenados()
        {
            List<Miembro> lista = new List<Miembro>();

            foreach(Usuario u in _listaUsuarios)
            {
                if (u is Miembro)
                {
                    Miembro m = u as Miembro;
                    lista.Add(m);
                }
            }
            lista.Sort();
            return lista;
        }

        public void CambiarLongitudDeTextoDePosts() /*Metodo de sistema, llamado en program, para alternar la longitud de texto a mostrar*/
        {
            foreach (Publicacion p in _listaPublicaciones)
            {
                if (p is Post)
                {
                    Post pAuxiliar = p as Post;
                    pAuxiliar.ModificarLongitudDeTexto();
                }
            }
        }

        public List<Post> ListarPostsPorFecha(DateTime fecha1, DateTime fecha2)
        {
            if (fecha1 > fecha2) (fecha1, fecha2) = (fecha2, fecha1);

            List<Post> posts = new List<Post>();

            foreach (Publicacion p in _listaPublicaciones)
            {
                if (p is Post && p.FechaCreacion >= fecha1 && p.FechaCreacion <= fecha2)
                {
                    Post pAux = p as Post;
                    if (!pAux.EstaCensurado) posts.Add(pAux);
                }
            }
            posts.Sort();

            return posts;
        }

        public List<Miembro> ObtenerMiembrosConMayoresPublicaciones()
        {
            List<Miembro> retorno = new List<Miembro>();
            int mayorCantPublis = 0;
            foreach (Usuario u in _listaUsuarios)
            {
                if (u is Miembro)
                {
                    List<Publicacion> publicaciones = ObtenerPublicacionesDeMiembro(u.Email);
                    int cantPublis = publicaciones.Count;
                    if (mayorCantPublis < cantPublis)
                    {
                        retorno.Clear();
                        retorno.Add(u as Miembro);
                        mayorCantPublis = cantPublis;
                    }
                    else if (mayorCantPublis == cantPublis)
                    {
                        retorno.Add(u as Miembro);
                    }
                }
            }
            return retorno;
        }

        public List<Publicacion> PublicacionesPorTextoYVA(string texto, int va)
        {
            List<Publicacion> retorno = new List<Publicacion>();

            foreach (Publicacion p in _listaPublicaciones)
            {
                if (p.CalcularVA() >= va)
                {
                    if (p.Titulo.ToUpper().Contains(texto.ToUpper())
                        || p.Contenido.ToUpper().Contains(texto.ToUpper())
                        || p.Texto.ToUpper().Contains(texto.ToUpper())) retorno.Add(p);
                }
            }
            return retorno;
        }

        public void CambiarContrasenia(Miembro m, string nuevaContra)
        {
            m.CambiarContrasenia(nuevaContra);
        }
    }
}