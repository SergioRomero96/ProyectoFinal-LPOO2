using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class TerminalRepository : Repository, ITerminalRepository
    {
        SqlDataAdapter _dataAdapter;
        DataTable _dataTable;

        public TerminalRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable ValidarCodigoTerminal(int codigoTerminal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_unico_codigo", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoTerminal", codigoTerminal);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        public DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_listar", CommandType.StoredProcedure);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        public int Add(Terminal entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_insertar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoTerminal", entity.Ter_Codigo);
            _command.Parameters.AddWithValue("@codigoCiudad", entity.Ciu_Codigo);
            _command.Parameters.AddWithValue("@nombreTerminal", entity.Ter_Nombre);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();

            return 0;
        }

        public void Update(Terminal entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_actualizar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@id", entity.Ter_Id);
            _command.Parameters.AddWithValue("@codigoTerminal", entity.Ter_Codigo);
            _command.Parameters.AddWithValue("@codigoCiudad", entity.Ciu_Codigo);
            _command.Parameters.AddWithValue("@nombreTerminal", entity.Ter_Nombre);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(Terminal entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_eliminar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoTerminal", entity.Ter_Codigo);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }


        public DataTable BuscarNombreTerminal(string nombreTerminal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_buscar_nombre", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@nombreTerminal", nombreTerminal);

            loadDataTable();
            return _dataTable;
        }

        private void loadDataTable()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }


        public int ValidarTerminalTieneServicio(int idTerminal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("terminal_tiene_servicio", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@idTerminal", idTerminal);

            _command.Parameters.Add("@band", SqlDbType.Int);
            _command.Parameters["@band"].Direction = ParameterDirection.Output;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();

            int cantidad = Convert.ToInt32(_command.Parameters["@band"].Value.ToString());
            return cantidad;
        }
    }
}