using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        DataTable ValidarCodigoTerminal(int codigoTerminal);
        DataTable BuscarNombreTerminal(string nombreTerminal);
        int ValidarTerminalTieneServicio(int idTerminal);
    }
}
