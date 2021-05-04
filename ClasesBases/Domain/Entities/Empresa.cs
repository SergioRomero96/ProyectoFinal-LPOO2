using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ClasesBases
{
    public class Empresa : IDataErrorInfo
    {
        private int Emp_Id;

        public int Id
        {
            get { return Emp_Id; }
            set { Emp_Id = value; }
        }
        private int Emp_Codigo;

        public int Codigo
        {
            get { return Emp_Codigo; }
            set { Emp_Codigo = value; }
        }
        private string Emp_Nombre;

        public string Nombre
        {
            get { return Emp_Nombre; }
            set { Emp_Nombre = value; }
        }
        private string Emp_Direccion;

        public string Direccion
        {
            get { return Emp_Direccion; }
            set { Emp_Direccion = value; }
        }
        private string Emp_Telefono;

        public string Telefono
        {
            get { return Emp_Telefono; }
            set { Emp_Telefono = value; }
        }
        private string Emp_Email;

        public string Email
        {
            get { return Emp_Email; }
            set { Emp_Email = value; }
        }

        public Empresa()
        {

        }


        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { 
                string msg_error = null;
                switch (columnName)
                {
                    case "Codigo":
                        msg_error = validateCod();
                        break;
                    case "Nombre":
                        msg_error = validateName();
                        break;
                    case "Direccion":
                        msg_error = validateDireccion();
                        break;

                    case "Telefono":
                        msg_error = validatePhone();
                        break;
                    case "Email":
                        msg_error = validateEmail();
                        break;
                }
                return msg_error;
            }
        }

        private string validateCod()
        {
            if (Codigo==0)
            { return "Este campo es obligatorio"; }
            return null;
        }
        private string validateName()
        {
            if (string.IsNullOrEmpty(Nombre))
            { return "Este campo es obligatorio"; }
            return null;
        }
        private string validateDireccion()
        {
            if (string.IsNullOrEmpty(Direccion))
            { return "Este campo es obligatorio"; }
            return null;
        }
        private string validatePhone()
        {
            if (string.IsNullOrEmpty(Telefono))
            { return "Este campo es obligatorio"; }
            if (Telefono.Length < 8) {
                return "El telefono debe contener al menos 8 digitos";
            }
            return null;
        }
        private string validateEmail()
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (string.IsNullOrEmpty(Email))
            { return "Este campo es obligatorio"; }
            if (!Regex.IsMatch(Email, expresion))
            {
                return "Correo invalido  formato: example@yahoo.com";
            }
            return null;
        }
        }
    }

