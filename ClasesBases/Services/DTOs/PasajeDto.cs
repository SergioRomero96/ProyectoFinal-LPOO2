using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases.Services.DTOs
{
    public class PasajeDto
    {
        public int Codigo { get; set; }
        public int NroAsiento { get; set; }
        public DateTime FechaHoraOperacion { get; set; }
        public ClienteDto Cliente { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaHoraPartida { get; set; }
        public string TipoServicio { get; set; }

        public PasajeDto()
        {
            Cliente = new ClienteDto();
        }
    }
}
