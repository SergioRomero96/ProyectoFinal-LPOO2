using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface ICiudadRepository : IRepository<Ciudad>
    {
        DataTable ValidarNombreCiudad(string nombreCiudad);
        DataTable ValidarCodigoCiudad(int codigoCiudad);
        int ValidarCiudadTieneTerminal(int codigoCiudad);
        DataTable BuscarNombreCiudad(string nombreCiudad);
    }
}
