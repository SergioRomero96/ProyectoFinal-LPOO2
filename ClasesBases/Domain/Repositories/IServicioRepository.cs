using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IServicioRepository: IRepository<Servicio>
    {
        DataTable FindServeiceByCode(int codigo);
        DataTable GetAlls();
        void UpdateStates(DateTime fecha);
        DataTable FindServiceByDate(Servicio service);
        void InsertSemanal(Servicio servicio);
        DataTable BuscarCodigoAutobus(int codigoAutobus);
    }
}
