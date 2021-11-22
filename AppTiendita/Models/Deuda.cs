using System;
using System.Collections.Generic;
using System.Text;

namespace AppTiendita.Models
{
   public class Deuda
    {
        public string nombrecliente { get; set; }
        public string apellidocliente { get; set; }

        public double totalcobrar { get; set; }
        public string nombrecompleto => $"{nombrecliente} {apellidocliente}";

        public string totaldeuda => $"{"$"} {totalcobrar}";
    }
}
