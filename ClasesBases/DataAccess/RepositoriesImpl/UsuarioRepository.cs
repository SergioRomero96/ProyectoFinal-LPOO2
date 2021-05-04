using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClasesBases.Domain.Repositories;
using System.Data.SqlClient;
using ClasesBases.Commons.Cache;

namespace ClasesBases.DataAccess.RepositoriesImpl
{
    public class UsuarioRepository:Repository, IUsuarioRepository
    {
        SqlDataAdapter _dataAdapter;
        DataTable _dataTable;
        DataSet _dataSet;

        public UsuarioRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable ValidarLogin(string userName, string password)
        {
            _command = new SqlCommand();
            SqlCommandConfig("users_validate_login", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@userName", userName);
            _command.Parameters.AddWithValue("@password", password);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
            
            if (_dataTable.Rows.Count == 1)
            {
                UserLoginCache.UserName = _dataTable.Rows[0][1].ToString();
                UserLoginCache.Rol = _dataTable.Rows[0][4].ToString();

                UserLoginCache.Id = Convert.ToInt32(_dataTable.Rows[0]["USU_Id"]);
               
            }

            return _dataTable;
        }

        public string GetRol(string id)
        {
            _command = new SqlCommand();
            SqlCommandConfig("usuario_obtener_rol", CommandType.StoredProcedure);
            
            //corregido ese copipasteo del edmundo
            //Parametro de Entrada
            _command.Parameters.AddWithValue("@codigo", id);

            //Parametro de Salida
            _command.Parameters.Add("@rol", SqlDbType.VarChar, 50);
            _command.Parameters["@rol"].Direction = ParameterDirection.Output;

            Commit();

            //Obtengo el valor del parametro de salida
            string rol = _command.Parameters["@rol"].Value.ToString();
            return rol;  
        }

        public DataTable GetAll()
        {
            _command = new SqlCommand();
            SqlCommandConfig("usuario_listar", CommandType.StoredProcedure);

          loadDataTable();
            return _dataTable;

        }

        private void addParameters(Usuario entity)
        {
            _command.Parameters.AddWithValue("@nomUsuario", entity.NombreUsuario);
            _command.Parameters.AddWithValue("@contraseña", entity.Contraseña);
            _command.Parameters.AddWithValue("@apelNombre", entity.ApellidoNombre);
            _command.Parameters.AddWithValue("@rol", entity.Rol.Codigo);
            _command.Parameters.AddWithValue("@email", entity.Email);
        }

        public int Add(Usuario entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("users_insert", CommandType.StoredProcedure);

            addParameters(entity);

            Commit();

            return 0;
        }

      

        public void Update(Usuario entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("users_update", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.ID);
            _command.Parameters.AddWithValue("@imagen", entity.Imagen);
            addParameters(entity);

            Commit();
        }

        public void Delete(Usuario entity)
        {
            _command = new SqlCommand();
            SqlCommandConfig("users_delete", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", entity.ID);

            Commit();
        }



        public DataSet GetRoles()
        {
            _command = new SqlCommand();
            SqlCommandConfig("rol_listar", CommandType.StoredProcedure);

            _dataAdapter = new SqlDataAdapter(_command);
            _dataSet= new DataSet();
            _dataAdapter.Fill(_dataSet, "Rol");
            return _dataSet;
        }


        public DataTable FindUserByUsername(string username)
        {
       
            _command = new SqlCommand();
            SqlCommandConfig("usuario_buscarPorNombreUsuario", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@username", username);

            loadDataTable();
            return _dataTable;
        }

        public DataTable FindUserById(int id)
        {
            _command = new SqlCommand();
            SqlCommandConfig("userFindById", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@id", id);

            loadDataTable();
            return _dataTable;
        }

        private void loadDataTable()
        {
            _dataAdapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _dataAdapter.Fill(_dataTable);
        }



        public DataTable GetOrdenar_Usuarios()
        {
            _command = new SqlCommand();
            SqlCommandConfig("usuario_ordenar", CommandType.StoredProcedure);

            loadDataTable();
            return _dataTable;
        }

        public void closeConexion() {
            _connection.Close();
        }

        public DataTable FindUserByEmail(Usuario usuario)
        {
            _command = new SqlCommand();
            SqlCommandConfig("user_validate_email", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@email", usuario.Email);
            _command.Parameters.AddWithValue("@usuario", usuario.NombreUsuario);
            loadDataTable();
            return _dataTable;
        }


        public DataTable BuscarNombreUsuario(string nombreUsuario)
        {
            _command = new SqlCommand();
            SqlCommandConfig("usuario_buscar_nombre", CommandType.StoredProcedure);
            _command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

            loadDataTable();
            return _dataTable;
        }
    }
}
