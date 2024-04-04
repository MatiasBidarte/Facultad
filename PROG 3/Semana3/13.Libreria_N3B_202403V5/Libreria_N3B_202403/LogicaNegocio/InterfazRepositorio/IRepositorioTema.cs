using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioTema: IRepositorio<Tema>
    {
        public IEnumerable<Tema> GetByName(string name);
    }
}
