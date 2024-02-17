using System;
namespace Dominio
{
	public class Sistema
	{
		private List<Cliente> _clientes = new List<Cliente>();

		public List<Cliente> Clientes
		{
			get { return _clientes; }
		}

		#region Singleton

		private static Sistema _instancia;

        private Sistema()
		{
			PrecargarClientes();
			PrecargarCuentasAClientes();

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

		private void PrecargarClientes()
		{
			AltaCliente(new Cliente("51263152", "Matias"));
            AltaCliente(new Cliente("54027810", "Emiliano"));
            AltaCliente(new Cliente("52537479", "Nicolas"));
            AltaCliente(new Cliente("12345678", "Santiago"));
        }

		private void PrecargarCuentasAClientes()
		{
			AgregarCuentaACliente("51263152", new Cuenta(Moneda.EUR));
            AgregarCuentaACliente("54027810", new Cuenta(Moneda.UYU));
            AgregarCuentaACliente("52537479", new Cuenta(Moneda.USD));
        }

		public void AltaCliente(Cliente c)
		{
			if (c == null) throw new Exception("el cliente no puede ser null");
			c.Validar();
			if (_clientes.Contains(c)) throw new Exception("no puede haber 2 clientes con la misma cedula");
			_clientes.Add(c);
		}

		public void AgregarCuentaACliente(string cedulaCli, Cuenta cuenta)
		{
			Cliente c = BuscarClientePorCedula(cedulaCli);
            if (c == null) throw new Exception($"cliente con la cedula {cedulaCli} no encontrado");
            c.AgregarCuenta(cuenta);
			
		}

		private Cliente BuscarClientePorCedula(string cedula)
		{
            Cliente c = null;
            int i = 0;

            while (c == null && i < _clientes.Count)
            {
                if (_clientes[i].Cedula == cedula) c = _clientes[i];
				i++;
            }
			return c;
        }

		public List<Cliente> ClientesEmpiezaConS()
		{
			List<Cliente> retorno = new List<Cliente>();

			foreach(Cliente c in _clientes)
			{
				if (char.ToUpper(c.Nombre[0]) == 'S') retorno.Add(c);
			}

			return retorno;
		}

		public List<Cliente> ClientesConMasDe2Cuentas()
		{
            List<Cliente> retorno = new List<Cliente>();

			foreach(Cliente c in _clientes)
			{
				if (c.MostrarCuentas().Count >= 2) retorno.Add(c);
			}

			return retorno;
        }
	}
}

