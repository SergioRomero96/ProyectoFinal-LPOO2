using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases
{
    public class Rol
    {
        private string Rol_Codigo;

        public string Codigo
        {
            get { return Rol_Codigo; }
            set { Rol_Codigo = value; }
        }
        private string Rol_Descripcion;

        public string Descripcion
        {
            get { return Rol_Descripcion; }
            set { Rol_Descripcion = value; }
        }

        public Rol(string rol_Codigo, string rol_Descripcion)
        {
            this.Rol_Codigo = rol_Codigo;
            this.Rol_Descripcion = rol_Descripcion;
        }

        public Rol()
        {
            
        }
    }
}
