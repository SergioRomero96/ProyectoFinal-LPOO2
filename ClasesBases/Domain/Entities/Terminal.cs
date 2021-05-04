using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBases
{
    public class Terminal : IDataErrorInfo
    {
        private int ter_Id;

        public int Ter_Id
        {
            get { return ter_Id; }
            set { ter_Id = value; }
        }

        private int ter_Codigo;

        public int Ter_Codigo
        {
            get { return ter_Codigo; }
            set { ter_Codigo = value; }
        }

        private int ciu_Codigo;

        public int Ciu_Codigo
        {
            get { return ciu_Codigo; }
            set { ciu_Codigo = value; }
        }

        private string ter_Nombre;

        public string Ter_Nombre
        {
            get { return ter_Nombre; }
            set { ter_Nombre = value; }
        }

        public Ciudad Ciudad { get; set; }

        public Terminal() 
        {
            Ciudad = new Ciudad();
        }

        public Terminal(int cdTerminal, int cdCiudad, string nombre)
        {
            this.ter_Codigo = cdTerminal;
            this.ciu_Codigo = cdCiudad;
            this.ter_Nombre = nombre;
        }

        public Terminal(int id, int cdTerminal, int cdCiudad, string nombre)
        {
            this.ter_Id = id;
            this.ter_Codigo = cdTerminal;
            this.ciu_Codigo = cdCiudad;
            this.ter_Nombre = nombre;
        }

        public string this[String columnName]
        {
            get
            {
                string msgError = String.Empty;
                switch (columnName)
                {
                    case "Ter_Codigo": msgError = ValidarCampo(ter_Codigo.ToString()); break;
                    case "Ciu_Codigo": msgError = ValidarCampo(ciu_Codigo.ToString()); break;
                    case "Ter_Nombre": msgError = ValidarCampo(ter_Nombre); break;
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

        public string Error
        {
            get { return null; }
        }
    }
}
