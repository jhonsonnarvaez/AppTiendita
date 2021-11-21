using System;
using System.Collections.Generic;
using System.Text;

namespace AppTiendita.Models
{
    public class Cliente
    {
        public int idcliente { get; set; }
        public string apellidocliente { get; set; }
        public string celularcliente { get; set; }
        public string correocliente { get; set; }
        public string direccioncliente { get; set; }
        public int estadocliente { get; set; }
        public string identificacioncliente { get; set; }
        public string nombrecliente { get; set; }
        public string telefonocliente { get; set; }
        public int ididentificacionpersona { get; set; }
        public int idsucursal { get; set; }

        public string nombrecompleto => $"{nombrecliente} {apellidocliente}";

    }
}
