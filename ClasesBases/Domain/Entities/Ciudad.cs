using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBases
{
    public class Ciudad : IDataErrorInfo
    {
        private int ciu_Id;

        public int Ciu_Id
        {
            get { return ciu_Id; }
            set { ciu_Id = value; }
        }

        private int ciu_Codigo;

        public int Ciu_Codigo
        {
            get { return ciu_Codigo; }
            set { ciu_Codigo = value; }
        }
        private string ciu_Nombre;

        public string Ciu_Nombre
        {
            get { return ciu_Nombre; }
            set { ciu_Nombre = value; }
        }

        public Ciudad() { }

        public Ciudad(int codigo, string nombreCiudad)
        {
            this.ciu_Codigo = codigo;
            this.ciu_Nombre = nombreCiudad;
        }

        public Ciudad(int id, int codigo, string nombreCiudad)
        {
            this.ciu_Id = id;
            this.ciu_Codigo = codigo;
            this.ciu_Nombre = nombreCiudad;
        }

        public string toString()
        {
            return "Codigo: " + this.ciu_Codigo + "\nNombre: " + this.ciu_Nombre;
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string msgError = String.Empty;
                switch (columnName)
                {
                    case "Ciu_Nombre": msgError = ValidarCampo(ciu_Nombre); break;
                    case "Ciu_Codigo": msgError = ValidarCampo(Ciu_Codigo.ToString()); break;
                }
                return msgError;
            }
        }

        private string ValidarCampo(string campo)
        {
            if (String.IsNullOrEmpty(campo))
                return "El valor del campo es requerido";
            return null;
        }
    }
}
