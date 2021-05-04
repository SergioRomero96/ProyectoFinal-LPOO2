using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class CiudadRepository : Repository, ICiudadRepository
    {
        SqlDataAdapter _dataAdapter;
        DataTable _dataTable;

        public CiudadRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable BuscarNombreCiudad(string nombreCiudad)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_buscar_nombre", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@nombreCiudad", nombreCiudad);

            loadDataTable();
            return _dataTable;
        }

        /*Consulta si la ciudad tiene terimal asignada*/
        public int ValidarCiudadTieneTerminal(int codigoCiudad)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_tiene_terminal", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@ciuId", codigoCiudad);

            _command.Parameters.Add("@band", SqlDbType.Int);
            _command.Parameters["@band"].Direction = ParameterDirection.Output;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();

            int cantidad = Convert.ToInt32(_command.Parameters["@band"].Value.ToString());
            return cantidad;
        }

        /*Valida que sea unico el codigo de ciudad*/
        public DataTable ValidarCodigoCiudad(int codigoCiudad)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_unico_codigo", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoCiudad", codigoCiudad);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        /*Valida que sea unico el nombre de ciudad*/
        public DataTable ValidarNombreCiudad(string nombreCiudad)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_unico_nombre", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@nombreCiudad", nombreCiudad);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        /*Obtener lista de ciudades*/
        public DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_listar", CommandType.StoredProcedure);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        /*Agregar una ciudad*/
        public int Add(Ciudad entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_insertar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoCiudad", entity.Ciu_Codigo);
            _command.Parameters.AddWithValue("@nombreCiudad", entity.Ciu_Nombre);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();

            return 0;
        }

        /*Actualizar una ciudad*/
        public void Update(Ciudad entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_actualizar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@id", entity.Ciu_Id);
            _command.Parameters.AddWithValue("@codigoCiudad", entity.Ciu_Codigo);
            _command.Parameters.AddWithValue("@nombreCiudad", entity.Ciu_Nombre);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        /*Eliminar una ciudad*/
        public void Delete(Ciudad entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("ciudad_eliminar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@id", entity.Ciu_Codigo);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void loadDataTable()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }
    }
}
