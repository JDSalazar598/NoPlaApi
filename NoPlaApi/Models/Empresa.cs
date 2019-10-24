using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Puesto = new HashSet<Puesto>();
            Usuario = new HashSet<Usuario>();
        }

        public int Idempresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal? Telefono { get; set; }
        public int Estado { get; set; }

        public ICollection<Puesto> Puesto { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
