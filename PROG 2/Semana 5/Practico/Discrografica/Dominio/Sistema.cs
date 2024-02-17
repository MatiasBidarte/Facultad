namespace Dominio
{
    public class Sistema
    {
        private List<Autor> _autores = new List<Autor>();
        private List<Cancion> _canciones = new List<Cancion>();
        private List<Disco> _discos = new List<Disco>();

        private static Sistema _instancia;

        private Sistema()
        {
            PrecargarAutores();
            PrecargarCanciones();
            PrecargarDiscos();
            AgregarCancionADisco();
        }

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }

        public List<Autor> Autores { get { return _autores; } }

        public List<Cancion> Canciones { get { return _canciones; } }

        public List <Disco> Discos { get {  return _discos; } }

        private void PrecargarAutores()
        {
            AltaAutor(new Solista("MatiSolista", "Uruguay", Sexo.MASCULINO, 10));
            AltaAutor(new Banda(6, "BandaDelEmi", "Uruguay"));
        }

        private void PrecargarCanciones()
        {
            AltaCancion(new Cancion(2, 120, "temita1"));
            AltaCancion(new Cancion(4, 200, "temita2"));
            AltaCancion(new Cancion(3, 250, "temita3"));
        }

        private void PrecargarDiscos()
        {
            AltaDisco(new Disco(BuscarAutor("MatiSolista"), "disco1", 2010, AltaPosCanciones("temita1", 1), 1));
        }

        public void AltaAutor(Autor autor)
        {
            if (autor == null) throw new Exception("El autor no puede ser vacio");
            autor.Validar();
            if (_autores.Contains(autor)) throw new Exception("No puede haber mas de un autor con el mismo nombre");
            _autores.Add(autor);
        }

        public void AltaCancion(Cancion cancion)
        {
            if (cancion == null) throw new Exception("La cancion no puede ser null");
            cancion.Validar();
            if (_canciones.Contains(cancion)) throw new Exception("La cancion ya existe en el sistema");
            _canciones.Add(cancion);
        }

        public void AltaDisco(Disco disco)
        {
            if (disco == null) throw new Exception("El disco no puede ser null");
            disco.Validar();
            _discos.Add(disco);
        }

        public Autor BuscarAutor(string nombreAutor)
        {
            Autor buscado = null;
            int i = 0;

            while (buscado == null && i < _autores.Count)
            {
                if (_autores[i].Nombre == nombreAutor) buscado = _autores[i];
                i++;
            }
            return buscado;
        }

        public Cancion BuscarCancion(string nombreCancion)
        {
            Cancion cancion = null;
            int i = 0;

            while(cancion == null && i < _canciones.Count)
            {
                if (_canciones[i].Nombre == nombreCancion) cancion = _canciones[i];
                i++;
            }
            return cancion;
        }

        private List<PosCancion> AltaPosCanciones(string nombreCancion, int pos)
        {
            List<PosCancion> canciones = new List<PosCancion>();
            PosCancion posCancion = new PosCancion(BuscarCancion(nombreCancion), pos);
            canciones.Add(posCancion);
            return canciones;
        }

        //Esta mal
        private void AgregarCancionADisco()
        {
            List<PosCancion> cancion = AltaPosCanciones("temita2", 2);
            _discos[0].AgregarCancionADisco(cancion[0]);
        }

        public List<Disco> ObtenerDiscosPorMinutos(int minutos)
        {
            List<Disco> discos = new List<Disco>();
            foreach(Disco disco in _discos)
            {
                if (minutos >= disco.Duracion) discos.Add(disco);
            }
            return discos;
        }

        public List<Autor> ObtenerAutoresPorPais (string pais)
        {
            List<Autor> autores = new List<Autor>();
            foreach(Autor autor in _autores)
            {
                if (autor.Pais.ToLower() == pais.ToLower()) autores.Add(autor);
            }
            return autores;
        }
    }
}