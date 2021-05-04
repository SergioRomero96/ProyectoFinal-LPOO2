using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases.Services.DTOs
{
    public class ServicioDto
    {


        public ServicioDto()
        {
            Autobus = new AutobusDto();
        }

        public int Codigo { get; set; }
        public DateTime FechaHora { get; set; }
        public AutobusDto Autobus { get; set; }
        public string TipoServicio { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; }

    }
}
