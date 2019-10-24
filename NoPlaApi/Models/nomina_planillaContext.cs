using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NoPlaApi.Models
{
    public partial class nomina_planillaContext : DbContext
    {
        public nomina_planillaContext()
        {
        }

        public nomina_planillaContext(DbContextOptions<nomina_planillaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<DepartamentoLaboral> DepartamentoLaboral { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<ProgramacionAsistencia> ProgramacionAsistencia { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        // Unable to generate entity type for table 'dbo.asistencia_empleado'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=nomina_planilla;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.Idasistencia);

                entity.ToTable("asistencia");

                entity.Property(e => e.Idasistencia).HasColumnName("idasistencia");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Programacion).HasColumnName("programacion");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.ProgramacionNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.Programacion)
                    .HasConstraintName("FK_asistencia_programacion_asistencia");
            });

            modelBuilder.Entity<DepartamentoLaboral>(entity =>
            {
                entity.HasKey(e => e.Iddepto);

                entity.ToTable("departamento_laboral");

                entity.Property(e => e.Iddepto).HasColumnName("iddepto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado);

                entity.ToTable("empleado");

                entity.Property(e => e.Idempleado).HasColumnName("idempleado");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iddepto).HasColumnName("iddepto");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto).HasColumnName("puesto");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.IddeptoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.Iddepto)
                    .HasConstraintName("FK_empleado_departamento_laboral");

                entity.HasOne(d => d.PuestoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empleado_puesto");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Idempresa);

                entity.ToTable("empresa");

                entity.Property(e => e.Idempresa).HasColumnName("idempresa");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("decimal(10, 0)");
            });

            modelBuilder.Entity<ProgramacionAsistencia>(entity =>
            {
                entity.HasKey(e => e.Idprogramacion);

                entity.ToTable("programacion_asistencia");

                entity.Property(e => e.Idprogramacion).HasColumnName("idprogramacion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraFin).HasColumnName("hora_fin");

                entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.Idpuesto);

                entity.ToTable("puesto");

                entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Puesto)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_puesto_empresa");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.Idtipo);

                entity.ToTable("tipo_usuario");

                entity.Property(e => e.Idtipo).HasColumnName("idtipo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("usuario");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaIdempresa).HasColumnName("empresa_idempresa");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario).HasColumnName("tipo_usuario");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpresaIdempresaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EmpresaIdempresa)
                    .HasConstraintName("FK_usuario_empresa");

                entity.HasOne(d => d.TipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuario)
                    .HasConstraintName("FK_usuario_tipo_usuario");
            });
        }
    }
}
