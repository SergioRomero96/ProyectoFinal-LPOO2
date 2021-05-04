using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases.Services.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
