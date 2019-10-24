using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class Asistencia
    {
        public int Idasistencia { get; set; }
        public string Descripcion { get; set; }
        public int? Tipo { get; set; }
        public int Estado { get; set; }
        public int? Programacion { get; set; }

        public ProgramacionAsistencia ProgramacionNavigation { get; set; }
    }
}
