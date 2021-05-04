using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class EmpresaRepository : Repository, IEmpresaRepository
    {

        public EmpresaRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public System.Data.DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("empresa_listar", CommandType.StoredProcedure);

            loadDataTable();
            return _dataTable;
        }

        public int Add(Empresa entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("empresa_insertar", CommandType.StoredProcedure);

            addParameters(entity);

            Commit();
            return 0;
        }

        private void addParameters(Empresa _entity)
        {
            _command.Parameters.AddWithValue("@codigo", _entity.Codigo);
            _command.Parameters.AddWithValue("@nombre", _entity.Nombre);
            _command.Parameters.AddWithValue("@direccion", _entity.Direccion);
            _command.Parameters.AddWithValue("@telefono", _entity.Telefono);
            _command.Parameters.AddWithValue("@email", _entity.Email);
        }

        public void Update(Empresa entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("empresa_actualizar", CommandType.StoredProcedure);

            addParameters(entity);
            _command.Parameters.AddWithValue("@id", entity.Id);

            Commit();
           
        }

        public void Delete(Empresa entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("empresa_eliminar", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.Id);

            Commit();
        }
        private void loadDataTable()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }

        public DataTable BuscarNombreEmpresa(string nombreEmpresa)
        {
            _command = new SqlCommand();
            SqlCommandConfig("empresa_buscar_nombre", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@nombreEmpresa", nombreEmpresa);

            loadDataTable();
            return _dataTable;
        }
    }
}
