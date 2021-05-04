using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBases.Commons
{
    public class Response
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
