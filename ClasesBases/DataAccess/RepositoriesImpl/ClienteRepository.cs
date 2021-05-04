using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;
namespace ClasesBases.DataAccess.RepositoriesImpl
{
    class ClienteRepository : Repository, IClienteRepository

    {
        
        public ClienteRepository(SqlConnection connection) {
            _connection = connection;
        }
        public DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_listar", CommandType.StoredProcedure);

            ExecuteQuery();
            return _dataTable;
        }
        private void addParameters(Cliente entity){
            _command.Parameters.AddWithValue("@dni", entity.Dni);
            _command.Parameters.AddWithValue("@nombre", entity.Nombre);
            _command.Parameters.AddWithValue("@apellido", entity.Apellido);
            _command.Parameters.AddWithValue("@telefono", entity.Telefono);
            _command.Parameters.AddWithValue("@email", entity.Email);
        }

        public int Add(Cliente entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_insertar", CommandType.StoredProcedure);
            addParameters(entity);
            Commit();

            return 0;
        }

        public void Update(Cliente entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_actualizar", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.Id);
            addParameters(entity);

            Commit();
        }

        public void Delete(Cliente entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_eliminar", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.Id);
            Commit();
        }

        public DataTable FindClientByDni(int dni)
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_buscarPorDni", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@dni", dni);

            ExecuteQuery();
            return _dataTable;
        }




        public DataTable FindClient(string key)
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_BuscarPorApellido", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@buscar", key);

            ExecuteQuery();
            return _dataTable;
        }
        private void loadDataTable()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }


        public DataTable GetLastClient()
        {
            _command = new SqlCommand();
            SqlCommandConfig("cliente_obtener_ultimo", CommandType.StoredProcedure);

            ExecuteQuery();
            return _dataTable;
        }
    }
}
