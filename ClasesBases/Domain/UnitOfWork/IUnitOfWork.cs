using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.Repositories;

namespace ClasesBases.Domain.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IClienteRepository Clientes { get; }
        IAutobusRepository Autobus { get; }
        ICiudadRepository Ciudades { get; }
        ITerminalRepository Terminales { get; }
        IPasajeRepository Pasajes { get; }
        IServicioRepository Servicios { get; }
        IEmpresaRepository Empresas { get; }
    }
}
