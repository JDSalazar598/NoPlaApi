using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class Empleado
    {
        public int Idempleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public decimal? Telefono { get; set; }
        public int Puesto { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Iddepto { get; set; }

        public DepartamentoLaboral IddeptoNavigation { get; set; }
        public Puesto PuestoNavigation { get; set; }
    }
}
