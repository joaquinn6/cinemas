using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinemas.Models.Entities
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
    }
}