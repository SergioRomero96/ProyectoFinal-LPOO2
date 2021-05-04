using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Collections.ObjectModel;

namespace ClasesBases
{
    public class WorkUsuario
    {
        DataTable dt;
        UnitOfWork _unitOfWorf;
        public ObservableCollection<Usuario> getUsuarios()
        {
            _unitOfWorf = new UnitOfWork();
            dt = _unitOfWorf.Usuarios.GetAll();
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();
            foreach (DataRow row in dt.Rows)
            {
                Usuario u1 = new Usuario();
                Rol rol = new Rol(row[5].ToString(), row[6].ToString());
                u1.ID = Convert.ToInt32(row[0]);
                u1.NombreUsuario = row[1].ToString();
                u1.Contraseña = row[2].ToString();
                u1.ApellidoNombre = row[3].ToString();
                u1.Rol = rol;
                listaUsuarios.Add(u1);
            }
            return listaUsuarios;
        }
       /* public ObservableCollection<Usuario> getUsuariosFiltrados(ObservableCollection<Usuario> usuarios)
        {
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();
            listaUsuarios = usuarios;
            return listaUsuarios;
        }*/
    }
}
