using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class ServicioRepository:Repository, IServicioRepository
    {

        public ServicioRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_listar_completo", CommandType.StoredProcedure);
            ExecuteQuery();
            return _dataTable;
        }

        public DataTable GetAlls()
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_listar", CommandType.StoredProcedure);
            ExecuteQuery();
            return _dataTable;
        }

        public int Add(Servicio entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_insertar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoAutoBus", entity.Aut_Codigo);
            _command.Parameters.AddWithValue("@fechaServicio", entity.Ser_FechaHora);
            _command.Parameters.AddWithValue("@codigoOrigenTerminal", entity.Ter_Codigo_Origen);
            _command.Parameters.AddWithValue("@codigoDestinoTerminal", entity.Ter_Codigo_Destino);
            _command.Parameters.AddWithValue("@estadoServicio", entity.Ser_Estado);
            Commit();

            return 0;
        }

        public void Update(Servicio entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_actualizar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoServicio", entity.Ser_Codigo);
            _command.Parameters.AddWithValue("@codigoAutoBus", entity.Aut_Codigo);
            _command.Parameters.AddWithValue("@fechaServicio", entity.Ser_FechaHora);
            _command.Parameters.AddWithValue("@codigoOrigenTerminal", entity.Ter_Codigo_Origen);
            _command.Parameters.AddWithValue("@codigoDestinoTerminal", entity.Ter_Codigo_Destino);
            _command.Parameters.AddWithValue("@estadoServicio", entity.Ser_Estado);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(Servicio entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_eliminar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoServicio", entity.Ser_Codigo);

            Commit();
        }

        public DataTable FindServeiceByCode(int codigo)
        {
            
            _command = new SqlCommand();
            SqlCommandConfig("servicio_find_by_bus", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigo",codigo);

            Commit();
            ExecuteQuery();
            return _dataTable;
        }

        public void UpdateStates(DateTime fecha)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_actualizar_estados", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@fecha", fecha);

            Commit();
        }


        public DataTable FindServiceByDate(Servicio service)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servico_find_by_datetime", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@fecha", service.Ser_FechaHora);
            _command.Parameters.AddWithValue("@codigo", service.Aut_Codigo);

            Commit();
            ExecuteQuery();
            return _dataTable;
        }


        public void InsertSemanal(Servicio servicio)
        {
           _command = new SqlCommand();
           SqlCommandConfig("servicio_insertar_semanal", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@codigoAutoBus", servicio.Aut_Codigo);
            _command.Parameters.AddWithValue("@fechaServicio", servicio.Ser_FechaHora);
            _command.Parameters.AddWithValue("@codigoOrigenTerminal", servicio.Ter_Codigo_Origen);
            _command.Parameters.AddWithValue("@codigoDestinoTerminal", servicio.Ter_Codigo_Destino);
            _command.Parameters.AddWithValue("@estadoServicio", servicio.Ser_Estado);
            Commit();

        }

        public DataTable BuscarCodigoAutobus(int codigoAutobus)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_buscar_autobus", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@codigoAutobus", codigoAutobus);
            Commit();
            ExecuteQuery();
            return _dataTable;
        }
    }
}
