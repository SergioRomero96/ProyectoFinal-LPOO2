using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBases
{
    public class Servicio : IDataErrorInfo
    {
        private int ser_Codigo;

        public int Ser_Codigo
        {
            get { return ser_Codigo; }
            set { ser_Codigo = value; }
        }
        private int aut_Codigo;

        public int Aut_Codigo
        {
            get { return aut_Codigo; }
            set { aut_Codigo = value; }
        }
        private DateTime ser_FechaHora;

        public DateTime Ser_FechaHora
        {
            get { return ser_FechaHora; }
            set { ser_FechaHora = value; }
        }
        private int ter_Codigo_Origen;

        public int Ter_Codigo_Origen
        {
            get { return ter_Codigo_Origen; }
            set { ter_Codigo_Origen = value; }
        }
        private int ter_Codigo_Destino;

        public int Ter_Codigo_Destino
        {
            get { return ter_Codigo_Destino; }
            set { ter_Codigo_Destino = value; }
        }
        private string ser_Estado;

        public string Ser_Estado
        {
            get { return ser_Estado; }
            set { ser_Estado = value; }
        }

        public Terminal TerminalOrigen { get; set; }
        public Terminal TerminalDestino { get; set; }

        public Servicio()
        {
            TerminalOrigen = new Terminal();
            TerminalDestino = new Terminal();
            Autobus = new Autobus();
            
        }

        public Autobus Autobus { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string msgError = String.Empty;
                switch (columnName)
                {
                    case "Ser_FechaHora": msgError = ValidarCampos(); break;
                   
                }
                return msgError;
            }
        }

        private string ValidarCampos()
        {
           if (Ser_FechaHora.Year < 2015 ) {
                return "Campo Requerido";
            }
           
            return null;
        }
    }
}
