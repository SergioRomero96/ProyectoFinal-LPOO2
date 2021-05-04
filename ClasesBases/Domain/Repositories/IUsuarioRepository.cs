using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IUsuarioRepository:IRepository<Usuario> 
    {
        DataTable ValidarLogin(string userName, string password);
        string GetRol(string id);
        DataSet GetRoles();
        DataTable FindUserByUsername(string username);
        DataTable GetOrdenar_Usuarios();
        void closeConexion();
        DataTable FindUserById(int id);
        DataTable FindUserByEmail(Usuario usuario);
        DataTable BuscarNombreUsuario(string nombreUsuario);
    }
}
