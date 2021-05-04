using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases.Services.DTOs
{
    public class TicketDto
    {
        public Cliente Cliente { get; set; }
        public Servicio Servicio { get; set; }
        public Pasaje Pasaje { get; set; }
    }
}
