using System;
using System.Collections.Generic;

namespace NoPlaApi.Models
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
        public int Estado { get; set; }
        public int? TipoUsuario { get; set; }
        public int? EmpresaIdempresa { get; set; }

        public Empresa EmpresaIdempresaNavigation { get; set; }
        public TipoUsuario TipoUsuarioNavigation { get; set; }
    }
}
