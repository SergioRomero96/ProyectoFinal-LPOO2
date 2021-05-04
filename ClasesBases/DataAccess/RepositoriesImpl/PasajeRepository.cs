using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClasesBases.DataAccess.RepositoriesImpl;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class PasajeRepository : Repository, IPasajeRepository
    {

        public PasajeRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable GetPasaje(int codigo)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_obtener", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@codigo", codigo);

            ExecuteQuery();

            return _dataTable;
        }

        public DataTable GetAll()
        {
            //throw new NotImplementedException();
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_listar_vista", CommandType.StoredProcedure);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        public int Add(Pasaje entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_insertar", CommandType.StoredProcedure);

            _command.Parameters.AddWithValue("@cliId", entity.Cli_Id);
            _command.Parameters.AddWithValue("@serCodigo", entity.Ser_Codigo);
            _command.Parameters.AddWithValue("@asiento", entity.Pas_Asiento);
            _command.Parameters.AddWithValue("@precio", entity.Pas_Precio);
            _command.Parameters.AddWithValue("@fechaHora", entity.Pas_FechaHora);

            SqlParameter idParam = new SqlParameter("id", SqlDbType.Int);
            idParam.Direction = ParameterDirection.Output;
            _command.Parameters.Add(idParam);

            Commit();

            int id = (int)idParam.Value;
            return id;
        }

        public void Update(Pasaje entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pasaje entity)
        {
         
             _command = new SqlCommand();
             SqlCommandConfig("pasaje_eliminar", CommandType.StoredProcedure);
             _command.Parameters.AddWithValue("@codigo", entity.Pas_Codigo);
             Commit();
        }

        public DataTable GetPasajeByServicio(int codigo)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_listar_por_servicio", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@codigo", codigo);

            ExecuteQuery();

            return _dataTable;
        }

        /*Metodos para filtros de pasajes*/
        public DataTable ObtenerPasajeDniCliente(int dni)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_listar_dni", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@dni", dni);

            ExecuteQuery();

            return _dataTable;
        }

        public DataTable ObtenerPasajeNombreEmpresa(string empresa)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_listar_empresa", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@empresa", empresa);

            ExecuteQuery();

            return _dataTable;
        }

        public DataTable ObtenerPasajeTipoServicio(string servicio)
        {
            _command = new SqlCommand();
            SqlCommandConfig("dbo.pasaje_listar_tiposervicio", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@tipoServicio", servicio);

            ExecuteQuery();

            return _dataTable;
        }

        public DataTable ObtenerPasajeFechaServicio(DateTime fechaInicial, DateTime fechaFinal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_listar_fechas", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            _command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

            ExecuteQuery();

            return _dataTable;
        }

        public int ObtenerCantidadPasajesVendidos(DateTime fechaInicial, DateTime fechaFinal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_contar_vendidos", CommandType.StoredProcedure);

            //Parametro de Entrada
            _command.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            _command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

            //Parametro de Salida
            _command.Parameters.Add("@cantidad", SqlDbType.Int);
            _command.Parameters["@cantidad"].Direction = ParameterDirection.Output;

            Commit();

            //Obtengo el valor del parametro de salida
            int cantidad = Convert.ToInt32(_command.Parameters["@cantidad"].Value.ToString());
            return cantidad;
        }

        public decimal ObtenerTotalPrecio(DateTime fechaInicial, DateTime fechaFinal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("pasaje_contar_precio", CommandType.StoredProcedure);

            //Parametro de Entrada
            _command.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            _command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

            //Parametro de Salida
            _command.Parameters.Add("@precio", SqlDbType.Decimal);
            _command.Parameters["@precio"].Direction = ParameterDirection.Output;

            Commit();

            //Obtengo el valor del parametro de salida
            decimal precio = Convert.ToDecimal(_command.Parameters["@precio"].Value.ToString());
            return precio;
        }

        public DateTime HorarioDeMasVentas(DateTime fechaInicial, DateTime fechaFinal)
        {
            _command = new SqlCommand();
            SqlCommandConfig("servicio_fecha_max", CommandType.StoredProcedure);

            //Parametro de Entrada
            _command.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            _command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

            Commit();
            return (DateTime)_dataTable.Rows[0]["SER_FechaHora"];

        }
    }
}
