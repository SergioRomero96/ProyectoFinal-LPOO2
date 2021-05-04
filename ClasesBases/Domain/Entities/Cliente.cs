using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace ClasesBases
{
    public class Cliente : IDataErrorInfo
    {
        private int Cli_Id;

        public int Id
        {
            get { return Cli_Id; }
            set { Cli_Id = value; }
        }
        private int Cli_Dni;

        public int Dni
        {
            get { return Cli_Dni; }
            set { Cli_Dni = value; }
        }
        private string Cli_Nombre;

        public string Nombre
        {
            get { return Cli_Nombre; }
            set { Cli_Nombre = value; }
        }
        private string Cli_Apellido;

        public string Apellido
        {
            get { return Cli_Apellido; }
            set { Cli_Apellido = value; }
        }
        private string Cli_Telefono;

        public string Telefono
        {
            get { return Cli_Telefono; }
            set { Cli_Telefono = value; }
        }
        private string Cli_Email;

        public string Email
        {
            get { return Cli_Email; }
            set { Cli_Email = value; }
        }

        public Cliente()
        {
            
        }
        public Cliente(int dni,string nombre,string apellido,string telefono,string email)
        {
            this.Cli_Dni = dni;
            this.Cli_Nombre = nombre;
            this.Cli_Apellido = apellido;
            this.Cli_Telefono = telefono;
            this.Cli_Email = email;
        }
        public string toString() {
            return "Nombre: " + this.Cli_Nombre + "\n Apellido: " + this.Cli_Apellido + "\n Dni: " + this.Cli_Dni + "\n Telefono: " + this.Cli_Telefono + "\n Email: " + this.Cli_Email;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string msg_error = null;
                switch (columnName)
                {
                    case "Email":
                        msg_error = validarEmailCliente();
                        break;
                    case "Nombre":
                        msg_error = validarNombreCliente();
                        break;
                    case "Dni":
                        msg_error = validarDniCliente();
                        break;

                    case "Telefono":
                        msg_error = validarTelefonoCliente();
                        break;

                    case "Apellido":
                        msg_error = validarApellidoCliente();
                        break;
                }
                return msg_error;
            }

        }
        private string validarEmailCliente()
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (string.IsNullOrEmpty(Email))
            {
              
                    return "El valor del campo es obligatorio";
            
            }
            else if (Email.Length < 6)
            {
                return "El correo debe ser de al menos 10 caracteres";
            }
            if(!Regex.IsMatch(Email,expresion)){
            return "Correo invalido  formato: example@yahoo.com"; 
            }
            return null;
        }
        private string validarNombreCliente()
        {

            if (string.IsNullOrEmpty(Nombre))
            {
                    return "El valor del campo es obligatorio";
              
            }
            else if (Nombre.Length <= 2)
            {
                return "El Nombre debe ser de al menos 3 caracteres";
            }
            return null;
        }
        private string validarDniCliente()
        {
            if (Dni.Equals(0))
            {
                return "El valor del campo es obligatorio";
            }
            else if (Dni.ToString().Length < 8)
            {

                return "El valor del Dni debe ser de 8 digitos";

            }


            return null;
        }
        private string validarApellidoCliente()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                return "El valor del campo es obligatorio";
            }
            else if (Apellido.Length < 4)
            {
                return "El Apellido debe ser de al menos 4 caracteres";
            }
            return null;
        }
        private string validarTelefonoCliente()
        {
            if (string.IsNullOrEmpty(Telefono))
            {
                return "El valor del campo es obligatorio";
            }
            else if (Telefono.Length < 9)
            {
                return "El Telefono debe ser de al menos 9 digitos";
            }
            return null;
        }
    }
}
