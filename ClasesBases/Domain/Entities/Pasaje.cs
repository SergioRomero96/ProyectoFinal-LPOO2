using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases
{
    public class Pasaje
    {
        private int pas_Codigo;

        public int Pas_Codigo
        {
            get { return pas_Codigo; }
            set { pas_Codigo = value; }
        }
        private int cli_Id;

        public int Cli_Id
        {
            get { return cli_Id; }
            set { cli_Id = value; }
        }
        private int ser_Codigo;

        public int Ser_Codigo
        {
            get { return ser_Codigo; }
            set { ser_Codigo = value; }
        }
        private int pas_Asiento;

        public int Pas_Asiento
        {
            get { return pas_Asiento; }
            set { pas_Asiento = value; }
        }
        private decimal pas_Precio;

        public decimal Pas_Precio
        {
            get { return pas_Precio; }
            set { pas_Precio = value; }
        }

        private DateTime pas_FechaHora;

        public DateTime Pas_FechaHora
        {
            get { return pas_FechaHora; }
            set { pas_FechaHora = value; }
        }

        public Pasaje()
        {
            Pas_FechaHora = DateTime.Now;
        }
    }
}
