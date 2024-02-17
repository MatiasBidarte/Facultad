using Dominio.Ordenamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Cargo> _cargos = new List<Cargo>();
        private List<Empleado> _empleados = new List<Empleado>();

        #region Singleton

        private static Sistema _instancia;

        private Sistema()
        {
            PrecargarCargos();
            PrecargarEmpleados();
        }

        public static Sistema Instancia
        {
            get
            {
                if( _instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }

        #endregion

        #region Properties
        public List<Cargo> Cargos
        {
            get { return _cargos; }
        }
        public List<Empleado> Empleados
        {
            get { return _empleados; }
        }
        #endregion

        private void PrecargarCargos()
        {
            AltaCargo(new Cargo("Jefe", 15000));
            AltaCargo(new Cargo("Jefe", 20000));
            AltaCargo(new Cargo("Secretario", 200));
            AltaCargo(new Cargo("Sub Jefe", 5000));
            AltaCargo(new Cargo("Asistente", 10));
            AltaCargo(new Cargo("Empleado", 800));
            AltaCargo(new Cargo("Oficial", 100));
        }

        private void PrecargarEmpleados()
        {
            AltaEmpleado(new Tercerizado("12345678", "Santiago", 50, ObtenerCargoPorNombre("Jefe"), Sexo.Masculino, new DateTime(2020, 8,12)));
            AltaEmpleado(new Tercerizado("12345670", "Lucia", 150, ObtenerCargoPorNombre("Gerente"), Sexo.Femenino, new DateTime(2021, 8, 12)));
            AltaEmpleado(new Contratado("12345679", "Carlos", 50, ObtenerCargoPorNombre("Gerente"), Sexo.Masculino, 6));
        }

        public void AltaCargo(Cargo c)
        {
            if (c == null) throw new Exception("El cargo no puede ser nulo");
            c.Validar();
            if (_cargos.Contains(c)) throw new Exception("Ya existe el cargo con ese nombre");
            _cargos.Add(c);
        }

        public void AltaEmpleado(Empleado e)
        {
            
            if (e == null) throw new Exception("El empleado no puede ser nulo");
            e.Validar();
            if (_empleados.Contains(e)) throw new Exception("Ya existe un empleado con esa cedula en el sistema");
            _empleados.Add(e);
        }

        private Cargo ObtenerCargoPorNombre(string nombre)
        {
            Cargo buscado = null;
            int i = 0;

            while(buscado == null && i < _cargos.Count)
            {
                if (_cargos[i].Nombre == nombre) buscado = _cargos[i];
                i++;
            }

            return buscado;
        }

        public List<Empleado> ListadoTercerizados()
        {
            List<Empleado> tercerizados = new List<Empleado>();
            foreach(Empleado e in _empleados)
            {
                if(e is Tercerizado) tercerizados.Add(e);
            }

            return tercerizados;
        }

        public List<Contratado> ListadoContratados()
        {
            List<Contratado> contratados = new List<Contratado>();
            foreach (Empleado e in _empleados)
            {
                if (e is Contratado) contratados.Add((Contratado)e);
            }

            return contratados;
        }

        public List<Cargo> CargosNombreASC()
        {
            List<Cargo> listadoOrdenado = _cargos;
            listadoOrdenado.Sort();
            return listadoOrdenado;
        }

        public List<Cargo> CargosNombreDESC()
        {
            List<Cargo> listadoOrdenado = _cargos;
            listadoOrdenado.Sort(new OrdenCargoNombreDesc());
            return listadoOrdenado;
        }
    }
}
