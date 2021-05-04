using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ClasesBases
{
    public class Usuario : IDataErrorInfo, INotifyPropertyChanged
    {
        private string Usu_ApellidoNombre;

        public string ApellidoNombre
        {
            get { return Usu_ApellidoNombre; }
            set
            {
                Usu_ApellidoNombre = value;
                notify(Usu_ApellidoNombre);
            }
        }


        private string Usu_Contraseña;

        public string Contraseña
        {
            get { return Usu_Contraseña; }
            set
            {
                Usu_Contraseña = value;
                notify(Usu_Contraseña);
            }
        }
        private int Usu_ID;

        public int ID
        {
            get { return Usu_ID; }
            set
            {
                Usu_ID = value;
                notify(Usu_ID.ToString());
            }
        }
        private string Usu_NombreUsuario;

        public string NombreUsuario
        {
            get { return Usu_NombreUsuario; }
            set
            {
                Usu_NombreUsuario = value;
                notify(Usu_NombreUsuario);
            }
        }
    
        public Usuario() { }

        public Usuario(int usu_ID, string usu_NombreUsuario, string usu_Contraseña, string usu_ApellidoNombre,Rol rol)
        {
            this.Usu_ID = usu_ID;
            this.Usu_NombreUsuario = usu_NombreUsuario;
            this.Usu_Contraseña = usu_Contraseña;
            this.Usu_ApellidoNombre = usu_ApellidoNombre;
            this.Rol = rol;
           
        }
        public string toString()
        {
            return "Apellido y Nombre: " + this.Usu_ApellidoNombre + "\n nombreUsuario: " + this.Usu_NombreUsuario + "\n Contraseña: " + this.Usu_Contraseña + "\n ID: " + this.Usu_ID + "\n Rol: " + this.Rol.Codigo;
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
                    case "ApellidoNombre":
                        msg_error = validarAyN();
                        break;
                    case "Contraseña":
                        msg_error = validarPass();
                        break;
                    case "NombreUsuario":
                        msg_error = validarUs();
                        break;

                    case "Rol_Codigo":
                        msg_error = validarRol();
                        break;
                    case "Email":
                        msg_error = validateEmail();
                        break;
                }
                return msg_error;
            }
        }

        private string validarRol()
        {
            if (Rol==null)
            {
                return "Este campo es obligatorio";
            }
            return null;
        }

        private string validarUs()
        {
            if (string.IsNullOrEmpty(NombreUsuario))
            { return "Este campo es obligatorio"; }
            return null;
        }

        private string validarPass()
        {
            if (string.IsNullOrEmpty(Contraseña))
            { return "Este campo es obligatorio"; }
            return null;
        }

        private string validarAyN()
        {
            if (string.IsNullOrEmpty(ApellidoNombre))
            { return "Este campo es obligatorio";   }
            return null;
        }
        private string validateEmail()
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (string.IsNullOrEmpty(Email)) {
                return null;
            }
            if (!Regex.IsMatch(Email, expresion))
            {
                return "Correo invalido  formato: example@yahoo.com";
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void notify(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public Rol Rol
        {
            get
            {
                return Usu_Rol;
            }
            set
            {
                Usu_Rol = value;
            }
        }

        private Rol Usu_Rol;

        private byte[] Usu_Imagen;

        public byte[] Imagen
        {
            get { return Usu_Imagen; }
            set { Usu_Imagen = value; }
        }

        private string Usu_Email;

        public string Email
        {
            get { return Usu_Email; }
            set { Usu_Email = value; }
        }


    }
}
