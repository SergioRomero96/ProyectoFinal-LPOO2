using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IPasajeRepository : IRepository<Pasaje>
    {
        DataTable GetPasaje(int codigo);
        DataTable GetPasajeByServicio(int codigo);

        DataTable ObtenerPasajeDniCliente(int dni);
        DataTable ObtenerPasajeNombreEmpresa(string empresa);
        DataTable ObtenerPasajeTipoServicio(string servicio);
        DataTable ObtenerPasajeFechaServicio(DateTime fechaInicial, DateTime fechaFinal);
        int ObtenerCantidadPasajesVendidos(DateTime fechaInicial, DateTime fechaFinal);
        decimal ObtenerTotalPrecio(DateTime fechaInicial, DateTime fechaFinal);
        DateTime HorarioDeMasVentas(DateTime fechaInicial, DateTime fechaFinal);
    }
}

