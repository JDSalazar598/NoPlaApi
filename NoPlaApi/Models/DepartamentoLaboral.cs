using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class DepartamentoLaboral
    {
        public DepartamentoLaboral()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int Iddepto { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public ICollection<Empleado> Empleado { get; set; }
    }
}
