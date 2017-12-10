using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinemas.Models.Entities
{
    public class Registro
    {
        public int RegistroId { get; set; }
        public Pelicula peliculas { get; set; }
        public Horario horarios { get; set; }
        public Recibo recibos { get; set; }
    }
}