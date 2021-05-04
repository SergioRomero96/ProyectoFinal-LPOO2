using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Domain.Repositories;
using ClasesBases.DataAccess.RepositoriesImpl;
using System.Data.SqlClient;

namespace ClasesBases.DataAccess.UnitOfWorkImpl
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SqlConnection _connection;

        public UnitOfWork()
        {
           _connection = new SqlConnection(ClasesBases.Properties.Settings.Default.conexion);
            Usuarios = new UsuarioRepository(_connection);
            Autobus = new AutoBusRepository(_connection);
            Clientes = new ClienteRepository(_connection);
            Ciudades = new CiudadRepository(_connection);
            Terminales = new TerminalRepository(_connection);
            Pasajes = new PasajeRepository(_connection);
            Servicios = new ServicioRepository(_connection);
            Empresas = new EmpresaRepository(_connection);
            
        }

        public IUsuarioRepository Usuarios { get; private set; }

        public IClienteRepository Clientes { get; private set; }

        public IAutobusRepository Autobus { get; private set; }

        public ICiudadRepository Ciudades { get; private set; }

        public ITerminalRepository Terminales { get; private set; }

        public IPasajeRepository Pasajes { get; private set; }

        public IServicioRepository Servicios { get; private set; }
        public IEmpresaRepository Empresas { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
