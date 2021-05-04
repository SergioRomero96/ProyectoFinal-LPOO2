using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Services.Extension
{
    public class ClienteMapper
    {
        private static Cliente _cliente;

        public static Cliente ToCliente(DataTable dt)
        {
            DataRow row = dt.Rows[0];
            
            _cliente = new Cliente();
            _cliente.Id = (int) row[0];
            _cliente.Dni = (int) row[1];
            _cliente.Nombre = row[2].ToString();
            _cliente.Apellido = row[3].ToString();
            _cliente.Telefono = row[4].ToString();
            _cliente.Email = row[5].ToString();
            return _cliente;
        }
    }
}
