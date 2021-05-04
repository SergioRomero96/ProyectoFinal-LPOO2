using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IEmpresaRepository:IRepository<Empresa>
    {
        DataTable BuscarNombreEmpresa(string nombreEmpresa);
    }
}
