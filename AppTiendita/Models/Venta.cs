using System;
using System.Collections.Generic;
using System.Text;

namespace AppTiendita.Models
{
   public class Venta
    {
        public DateTime fechaventa { get; set; }
        public double total { get; set; }

        public string precio => $"{"$"} {total}";
    }
}
