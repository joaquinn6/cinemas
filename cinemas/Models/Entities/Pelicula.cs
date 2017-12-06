using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinemas.Models.Entities
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public string Poster { get; set; }
        public string Estado { get; set; }
    }
}