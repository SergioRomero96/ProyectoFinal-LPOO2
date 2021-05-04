using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases
{
   public class WorkClient
    {
       public static bool submit = false;
        public Cliente getCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.Email = "";
            oCliente.Apellido = "";
            oCliente.Dni = 0;
            oCliente.Telefono = "";
            oCliente.Nombre = "";
            return oCliente;
        }
    }
}
