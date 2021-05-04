using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases.Services.DTOs
{
    public class AutobusDto
    {
        public int Codigo { get; set; }
        public int NroAutobus { get; set; }
        public int Capacidad { get; set; }
        public string Empresa { get; set; }

        public AutobusDto()
        {
            // TODO: Complete member initialization
        }
    }
}
