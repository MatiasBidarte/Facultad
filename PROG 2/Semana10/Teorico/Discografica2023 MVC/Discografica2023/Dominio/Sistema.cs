using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        #region Singleton
        private static Sistema _instancia;

        private Sistema()
        {
            //Precargas
            PrecargarMusicos();
            PrecargarDiscos();
            PrecargarCanciones();
            PrecargarCancionesADiscos();
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

        private List<Disco> _discos = new List<Disco>();
        private List<Cancion> _canciones = new List<Cancion>();
        private List<Musico> _musicos = new List<Musico>();

        public List<Disco> Discos
        {
            get { return _discos; }
        }

        public List<Cancion> Canciones
        {
            get { return _canciones; }
        }

        public List<Musico> Musicos
        {
            get { return _musicos; }
        }

        private void PrecargarMusicos()
        {
            AltaMusico(new Banda("Cuarteto de Nos", "Uruguay", 5));
            AltaMusico(new Solista("Michael Jackson", "USA", Sexo.Masculino, 5));
            AltaMusico(new Banda("Red Hot Chilli Peppers", "USA", 4));
        }

        private void PrecargarDiscos()
        {
            try
            {
                AltaDisco(new Disco("DISK001", ObtenerMusicoPorNombre("Cuarteto de Nos"), "Jueves", 2019));
                AltaDisco(new Disco("DISK002", ObtenerMusicoPorNombre("Michael Jackson"), "Thriller", 1982));
                AltaDisco(new Disco("DISK003", ObtenerMusicoPorNombre("Red Hot Chilli Peppers"), "Californication", 1999));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PrecargarCanciones()
        {
            AltaCancion(new Cancion("Cancion 1", 12, 50));
            AltaCancion(new Cancion("Cancion 2", 7, 30));
            AltaCancion(new Cancion("Cancion 3", 10, 150));

            AltaCancion(new Cancion("Cancion 4", 2, 10));
            AltaCancion(new Cancion("Cancion 5", 1, 22));
            AltaCancion(new Cancion("Cancion 6", 8, 98));

            AltaCancion(new Cancion("Cancion 7", 12, 50));
            AltaCancion(new Cancion("Cancion 8", 7, 30));
            AltaCancion(new Cancion("Cancion 9", 10, 150));
        }

        private void PrecargarCancionesADiscos()
        {
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK001"), new PosicionCancion(1, ObtenerCancionPorCodigo(1)));
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK001"), new PosicionCancion(2, ObtenerCancionPorCodigo(2)));
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK001"), new PosicionCancion(14, ObtenerCancionPorCodigo(3)));

            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK002"), new PosicionCancion(1, ObtenerCancionPorCodigo(4)));
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK002"), new PosicionCancion(2, ObtenerCancionPorCodigo(5)));
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK002"), new PosicionCancion(14, ObtenerCancionPorCodigo(6)));

            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK003"), new PosicionCancion(1, ObtenerCancionPorCodigo(7)));
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK003"), new PosicionCancion(2, ObtenerCancionPorCodigo(8)));
            AgregarCancionADisco(ObtenerDiscoPorCodigo("DISK003"), new PosicionCancion(3, ObtenerCancionPorCodigo(9)));
        }

        public void AltaMusico(Musico m)
        {
            try
            {
                if (m == null) throw new Exception("El objeto musico no puede ser nulo");
                m.Validar();
                ValidarQueNoExisteMusico(m);
                _musicos.Add(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarQueNoExisteMusico(Musico m)
        {
            if (m == null) throw new Exception("El musico no puede ser nulo");
            if (_musicos.Contains(m)) throw new Exception("El musico ya existe en el sistema");
        }

        public void AltaDisco(Disco d)
        {
            try
            {
                if (d == null) throw new Exception("El objeto disco no puede ser nulo");
                d.Validar();
                ValidarQueNoExisteDisco(d);
                _discos.Add(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public void AltaCancion(Cancion c)
        {
            if (c == null) throw new Exception("El objeto cancion no puede ser nulo");
            c.Validar();
            if (_canciones.Contains(c)) throw new Exception("Ya existe cancion con el nombre dado");
            _canciones.Add(c);
        }

        private void ValidarQueNoExisteDisco(Disco d)
        {
            if (d == null) throw new Exception("El disco no puede ser nulo");
            if (_discos.Contains(d)) throw new Exception("Un disco con ese codigo ya existe en el sistema");
        }

        public Musico ObtenerMusicoPorNombre(string nombre)
        {
            Musico m = null;
            int i = 0;
            while (m == null && i < _musicos.Count)
            {
                if (_musicos[i].Nombre == nombre) m = _musicos[i];
                i++;
            }

            return m;
        }

        public Disco ObtenerDiscoPorCodigo(string codigo)
        {
            Disco d = null;
            int i = 0;
            while (d == null && i < _discos.Count)
            {
                if (_discos[i].Codigo == codigo) d = _discos[i];
                i++;
            }

            return d;
        }

        public Cancion ObtenerCancionPorCodigo(int codigo)
        {
            Cancion c = null;
            int i = 0;
            while (c == null && i < _canciones.Count)
            {
                if (_canciones[i].Id == codigo) c = _canciones[i];
                i++;
            }

            return c;
        }

        public void AgregarCancionADisco(Disco d, PosicionCancion pc)
        {
            try
            {
                if (d == null) throw new Exception("El objeto disco no puede ser nulo");
                if (pc == null) throw new Exception("La posicion cancion no puede ser nula");
                d.AgregarCancionADisco(pc);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Disco> DiscosConDuracionMayorQue(double duracion)
        {
            List<Disco> listado = new List<Disco>();
            foreach(Disco d in _discos)
            {
                if(d.DuracionTotal() > duracion) listado.Add(d);
            }
            return listado;
        }

        public List<Musico> MusicosPorPais(string pais)
        {
            List<Musico> listado = new List<Musico>();
            foreach (Musico m in _musicos)
            {
                if (m.Pais == pais) listado.Add(m);
            }
            return listado;
        }

        public List<Disco> DiscosMasCarosQue(double precio)
        {
            List<Disco> listado = new List<Disco>();
            foreach (Disco d in _discos)
            {
                if (d.CalcularPrecio() > precio) listado.Add(d);
            }

            listado.Sort();
            return listado;
        }

        public List<Disco> DiscosConCancion(int codigo)
        {
            List<Disco> discos = new List<Disco>();
            Cancion c = ObtenerCancionPorCodigo(codigo);
            if (c == null) throw new Exception("Cancion no encontrada");
            
            foreach (Disco d in _discos)
            {
                if(d.TengoCancion(c)) discos.Add(d);
            }

            return discos;
        }

        public List<Disco> DiscosConMayorDuracion()
        {
            double duracionMax = double.MinValue;
            List<Disco> discos = new List<Disco>();

            foreach (Disco d in _discos)
            {
                if(d.DuracionTotal() > duracionMax)
                {
                    duracionMax = d.DuracionTotal();
                    discos.Clear();
                    discos.Add(d);
                }
                else if (d.DuracionTotal() == duracionMax)
                {
                    discos.Add(d);
                }
            }

            return discos;
        }

        private bool TieneDisco(Musico m)
        {
            bool tiene = false;
            int i = 0;
            while(!tiene && i < _discos.Count)
            {
                if (_discos[i].Musico.Equals(m)) tiene = true;
                i++;
            }

            return tiene;
        }

        public List<Musico> MusicosSinDiscos()
        {
            List<Musico> listado = new List<Musico>();
            
            foreach(Musico m in _musicos)
            {
                if(!TieneDisco(m)) listado.Add(m);
            }

            return listado;
        }
    }
}
