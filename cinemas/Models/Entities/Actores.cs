using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinemas.Models.Entities
{
    public class Actores
    {
        public int ActoresId { get; set; }
        public string Nombre { get; set; }
        public string Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Perfil { get; set; }
    }
}