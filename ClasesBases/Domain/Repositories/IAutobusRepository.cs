using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IAutobusRepository:IRepository<Autobus>
    {
        DataTable getEmpresas();
        DataTable FindByEmpresas(int codigo);
        DataTable BuscarMatricula(string matricula);
    }
}
