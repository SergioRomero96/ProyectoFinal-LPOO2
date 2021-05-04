using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class AutoBusRepository : Repository, IAutobusRepository
    {
        SqlDataAdapter _dataAdapter;
        DataTable _dataTable;

        public AutoBusRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("autobus_listar", CommandType.StoredProcedure);

            loadDataTable();
            return _dataTable;
        }

        private void addParameters(Autobus entity)
        {

            _command.Parameters.AddWithValue("@codigo", entity.Codigo);
            _command.Parameters.AddWithValue("@capacidad", entity.Capacidad);
            _command.Parameters.AddWithValue("@tipoServicio", entity.TipoServicio);
            _command.Parameters.AddWithValue("@matricula", entity.Matricula);
            _command.Parameters.AddWithValue("@empresa", entity.Empresa.Codigo);
            _command.Parameters.AddWithValue("@pisos", entity.CantidadPisos);
            _command.Parameters.AddWithValue("@imagen", entity.Imagen);
        }
        public int Add(Autobus entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("autobus_insertar", CommandType.StoredProcedure);
            addParameters(entity);

            Commit();

            return 0;
        }

        public void Update(Autobus entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("autobus_actualizar", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.Id);
            addParameters(entity);

            Commit();
        }

        public void Delete(Autobus entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("autobus_eliminar", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.Id);

            Commit();
        }

        public DataTable getEmpresas()
        {
            _command = new SqlCommand();
            SqlCommandConfig("empresa_listar", CommandType.StoredProcedure);

            loadDataTable();
            return _dataTable;
        }
        private void loadDataTable()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }


        public DataTable FindByEmpresas(int codigo)
        {
             _command = new SqlCommand();
             SqlCommandConfig("autobus_findByEmpresa", CommandType.StoredProcedure);
             _command.Parameters.AddWithValue("@codigo", codigo);

            loadDataTable();
            return _dataTable;
        }


        public DataTable BuscarMatricula(string matricula)
        {
            _command = new SqlCommand();
            SqlCommandConfig("autobus_buscar_matricula", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@matricula", matricula);

            loadDataTable();
            return _dataTable;
        }
    }
}
