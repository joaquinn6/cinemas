using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinemas.Models.Entities
{
    public class Recibo
    {
        public int ReciboId{ get; set; }
        public int id_pe_ho { get; set; }
        public string fechaPelicula { get;  set;}
        public string fechaNow { get; set; }
        public string cliente { get; set; }
        public string asiento { get; set; }
        public string codigo { get; set; }

        public string correo { get; set; }
    }
}