using System;
using System.Collections.Generic;
using System.Text;

namespace AppTiendita.Models
{
    public class Sucursal
    {
        public int idsucursal { get; set; }
        public string codigosucursal { get; set; }
        public string direccionsucursal { get; set; }
        public int estadosucursal { get; set; }
        public int idpropietario { get; set; }
        public int idtienda { get; set; }

    }
}
