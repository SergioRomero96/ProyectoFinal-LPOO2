using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBases
{
    public class Autobus : IDataErrorInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int Aut_Codigo;

        public int Codigo
        {
            get { return Aut_Codigo; }
            set { Aut_Codigo = value; }
        }
        private int Aut_Capacidad;

        public int Capacidad
        {
            get { return Aut_Capacidad; }
            set { Aut_Capacidad = value; }
        }
        private string Aut_TipoServicio;

        public string TipoServicio
        {
            get { return Aut_TipoServicio; }
            set { Aut_TipoServicio = value; }
        }
        private string Aut_Matricula;

        public string Matricula
        {
            get { return Aut_Matricula; }
            set { Aut_Matricula = value; }
        }

        public Autobus()
        {
            Aut_Empresa = new Empresa();
        }

        public Autobus(int codigo, int capacidad, string tipoServicio, string matricula)
        {
            Aut_Empresa = new Empresa();
            this.Aut_Codigo = codigo;
            this.Aut_Capacidad = capacidad;
            this.Aut_TipoServicio = tipoServicio;
            this.Aut_Matricula = matricula;
        }

        public string toString()
        {
            return "Codigo: " + this.Aut_Codigo + "\n Capacidad: " + this.Aut_Capacidad + "\n Tipo: " + this.Aut_TipoServicio + "\n Matricula: " + this.Aut_Matricula;
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
                    case "Codigo": msgError = ValidarCodigo(); break;
                    case "Empresa": msgError = ValidarEmpresa(Empresa); break;
                    case "Capacidad": msgError = ValidarCapacidad(); break;
                    case "TipoServicio": msgError = ValidarCampo(TipoServicio); break;
                    case "Matricula": msgError = ValidarCampo(Matricula); break;
                }
                return msgError;
            }
        }

        private string ValidarEmpresa(ClasesBases.Empresa Empresa)
        {
            if (Empresa.Codigo == 0 || Empresa.Codigo == null)
            {
                return "El valor del campo es requerido";
            }
            return null;
        }

        private string ValidarCampo(string campo)
        {
            if (String.IsNullOrEmpty(campo))
                return "El valor del campo es requerido";
            return null;
        }
        private string ValidarCodigo()
        {
            if (Codigo == 0)
            {
                return "El valor del campo es requerido";
            }
            return null;
        }
        private string ValidarCapacidad()
        {
            if (Capacidad == 0)
            {
                return "El valor del campo es requerido";
            }
            return null;
        }

        private int Aut_CantidadPisos;

        public int CantidadPisos
        {
            get { return Aut_CantidadPisos; }
            set { Aut_CantidadPisos = value; }
        }
        private byte[] Aut_Imagen;

        public byte[] Imagen
        {
            get { return Aut_Imagen; }
            set { Aut_Imagen = value; }
        }
        public Empresa Empresa
        {
            get
            {
                return Aut_Empresa;
            }
            set
            {
                Aut_Empresa = value;
            }
        }

        private Empresa Aut_Empresa;
    }
}
