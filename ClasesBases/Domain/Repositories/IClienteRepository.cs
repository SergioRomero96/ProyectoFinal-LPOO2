using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IClienteRepository:IRepository<Cliente>
    {

        DataTable FindClientByDni(int dni);
        DataTable FindClient(string key);
        DataTable GetLastClient();
    }
}
