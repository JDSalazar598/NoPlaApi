using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int Idpuesto { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public decimal Salario { get; set; }
        public int? IdEmpresa { get; set; }

        public Empresa IdEmpresaNavigation { get; set; }
        public ICollection<Empleado> Empleado { get; set; }
    }
}
