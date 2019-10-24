using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class ProgramacionAsistencia
    {
        public ProgramacionAsistencia()
        {
            Asistencia = new HashSet<Asistencia>();
        }

        public int Idprogramacion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int Estado { get; set; }

        public ICollection<Asistencia> Asistencia { get; set; }
    }
}
