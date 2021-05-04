using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    //No se puede instanciar
    public abstract class Repository
    {
        protected SqlConnection _connection;
        protected SqlCommand _command;
        protected SqlDataAdapter _dataAdapter;
        protected DataTable _dataTable;

        public void SqlCommandConfig(string command, CommandType type)
        {
            _command.CommandText = command;
            _command.CommandType = type;
            _command.Connection = _connection;
        }

        public void Commit()
        {
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            
        }

        public void ExecuteQuery()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }
        
    }
}
