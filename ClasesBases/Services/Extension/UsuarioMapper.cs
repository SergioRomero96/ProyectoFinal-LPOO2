using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Services.Extension
{
    public class UsuarioMapper
    {
        private static Usuario _usuario;
        public static Usuario ToUser(DataTable dt)
        {
            DataRow row = dt.Rows[0];
            _usuario = new Usuario();

            _usuario.ID = (int)row["USU_Id"];

            if (row["USU_Imagen"].ToString() != "")
                _usuario.Imagen = (byte[])row["USU_Imagen"];

            _usuario.NombreUsuario = row["USU_NombreUsuario"].ToString();
            _usuario.Contraseña = row["USU_Contraseña"].ToString();
            Rol rol = new Rol(row["ROL_Codigo"].ToString(), "");
            _usuario.Rol = rol;
            _usuario.Email = row["USU_Email"].ToString();
            _usuario.ApellidoNombre = row["USU_ApellidoNombre"].ToString();
            return _usuario;
        }
    }
}
