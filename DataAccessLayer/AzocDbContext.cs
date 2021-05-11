using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessObjectsLayer.Models;

#nullable disable

namespace DataAccessLayer
{
    public partial class AzocDbContext : DbContext
    {
        public AzocDbContext()
        {
        }

        public AzocDbContext(DbContextOptions<AzocDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Aportacion> Aportacions { get; set; }
        public virtual DbSet<Asociado> Asociados { get; set; }
        public virtual DbSet<Beneficiario> Beneficiarios { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<CategoriaAsociado> CategoriaAsociados { get; set; }
        public virtual DbSet<Credito> Creditos { get; set; }
        public virtual DbSet<Cuota> Cuota { get; set; }
        public virtual DbSet<Deduccion> Deduccions { get; set; }
        public virtual DbSet<DeduccionCredito> DeduccionCreditos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoCredito> EstadoCreditos { get; set; }
        public virtual DbSet<EstadoCuota> EstadoCuota { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<PermisoUsuario> PermisoUsuarios { get; set; }
        public virtual DbSet<TipoCuota> TipoCuota { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<RegistroUsuario> RegistroUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=AzocDb; User Id=sa; Password=_Mi@Sqlserver$Jevc&27!");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Aportacion>(entity =>
            {
                entity.ToTable("Aportacion");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Fuente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.Asociado)
                    .WithMany(p => p.Aportaciones)
                    .HasForeignKey(d => d.AsociadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aportacio__Asoci__5DCAEF64");
            });

            modelBuilder.Entity<Asociado>(entity =>
            {
                entity.ToTable("Asociado");

                entity.HasIndex(e => e.Telefono, "UQ__Asociado__4EC50480CD961316")
                    .IsUnique();

                entity.HasIndex(e => e.Dui, "UQ__Asociado__C0317D91412822E5")
                    .IsUnique();

                entity.HasIndex(e => e.Nit, "UQ__Asociado__C7D1D6DAA8E25C44")
                    .IsUnique();

                entity.Property(e => e.AsociadoId).ValueGeneratedNever();

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ingreso).HasColumnType("date");

                entity.Property(e => e.Retiro).HasColumnType("date");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TercerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TercerNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriaAsociado)
                    .WithMany(p => p.Asociados)
                    .HasForeignKey(d => d.CategoriaAsociadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asociado__Catego__3D5E1FD2");
            });

            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.ToTable("Beneficiario");

                entity.HasIndex(e => e.Telefono, "UQ__Benefici__4EC50480804A089C")
                    .IsUnique();

                entity.HasIndex(e => e.Dui, "UQ__Benefici__C0317D91F47B0EF8")
                    .IsUnique();

                entity.HasIndex(e => e.Nit, "UQ__Benefici__C7D1D6DAE3F66C52")
                    .IsUnique();

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TercerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TercerNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Asociado)
                    .WithMany(p => p.Beneficiarios)
                    .HasForeignKey(d => d.AsociadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Beneficia__Asoci__4316F928");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargo");

                entity.HasIndex(e => e.Nombre, "UQ__Cargo__75E3EFCF0E5027F9")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoriaAsociado>(entity =>
            {
                entity.ToTable("CategoriaAsociado");

                entity.HasIndex(e => e.Nombre, "UQ__Categori__75E3EFCF5006D49A")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.ToTable("Credito");

                entity.Property(e => e.CreditoId).ValueGeneratedNever();

                entity.Property(e => e.FechaAprobacion).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.Asociado)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.AsociadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Credito__Asociad__48CFD27E");

                entity.HasOne(d => d.EstadoCredito)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.EstadoCreditoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Credito__EstadoC__49C3F6B7");
            });

            modelBuilder.Entity<Cuota>(entity =>
            {
                entity.HasKey(e => e.CuotaId)
                    .HasName("PK__Cuota__319DB38129C944DD");

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.Credito)
                    .WithMany(p => p.Cuotas)
                    .HasForeignKey(d => d.CreditoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cuota__CreditoId__5441852A");

                entity.HasOne(d => d.EstadoCuota)
                    .WithMany(p => p.Cuota)
                    .HasForeignKey(d => d.EstadoCuotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cuota__EstadoCuo__534D60F1");

                entity.HasOne(d => d.TipoCuota)
                    .WithMany(p => p.Cuota)
                    .HasForeignKey(d => d.TipoCuotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cuota__CreditoId__52593CB8");
            });

            modelBuilder.Entity<Deduccion>(entity =>
            {
                entity.ToTable("Deduccion");

                entity.HasIndex(e => e.Nombre, "UQ__Deduccio__75E3EFCFFAAB835F")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeduccionCredito>(entity =>
            {
                entity.ToTable("DeduccionCredito");

                entity.HasOne(d => d.Credito)
                    .WithMany(p => p.DeduccionesCredito)
                    .HasForeignKey(d => d.CreditoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deduccion__Credi__5AEE82B9");

                entity.HasOne(d => d.Deduccion)
                    .WithMany(p => p.DeduccionCreditos)
                    .HasForeignKey(d => d.DeduccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deduccion__Credi__59FA5E80");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");

                entity.HasIndex(e => e.Telefono, "UQ__Empleado__4EC50480A44A864A")
                    .IsUnique();

                entity.HasIndex(e => e.Dui, "UQ__Empleado__C0317D919FB2F25C")
                    .IsUnique();

                entity.HasIndex(e => e.Nit, "UQ__Empleado__C7D1D6DAFA315F35")
                    .IsUnique();

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacimiento).HasColumnType("date");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TercerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TercerNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado__CargoI__2D27B809");
            });

            modelBuilder.Entity<EstadoCredito>(entity =>
            {
                entity.ToTable("EstadoCredito");

                entity.HasIndex(e => e.Nombre, "UQ__EstadoCr__75E3EFCF4CCAF637")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoCuota>(entity =>
            {
                entity.HasKey(e => e.EstadoCuotaId)
                    .HasName("PK__EstadoCu__D9B753FBBA847C7D");

                entity.HasIndex(e => e.Nombre, "UQ__EstadoCu__75E3EFCF2506DCFD")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permiso");

                entity.HasIndex(e => e.Nombre, "UQ__Permiso__75E3EFCF45ECB16B")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermisoUsuario>(entity =>
            {
                entity.ToTable("PermisoUsuario");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.PermisoUsuarios)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PermisoUs__Permi__34C8D9D1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PermisoUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PermisoUsuario_Usuario");
            });

            modelBuilder.Entity<TipoCuota>(entity =>
            {
                entity.HasKey(e => e.TipoCuotaId)
                    .HasName("PK__TipoCuot__E969AE3A9C3BD901");

                entity.HasIndex(e => e.Nombre, "UQ__TipoCuot__75E3EFCF2CD65B49")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Nombre, "UQ__Usuario__75E3EFCF3FEC7525")
                    .IsUnique();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .IsUnicode(false);
                
                entity.Property(e => e.Respuesta1)
                    .IsRequired()
                    .IsUnicode(false);
                
                entity.Property(e => e.Respuesta2)
                    .IsRequired()
                    .IsUnicode(false);
                
                entity.Property(e => e.Respuesta3)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__Emplead__30F848ED");
            });

            modelBuilder.Entity<RegistroUsuario>(entity =>
            {
                entity.ToTable("RegistroUsuario");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Informacion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Registro)
                    .WithMany(p => p.RegistroUsuarios)
                    .HasForeignKey(d => d.RegistroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroU__Regis__19DFD96B");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RegistroUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroU__Regis__18EBB532");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.ToTable("Registro");

                entity.HasIndex(e => e.Nombre, "UQ__Registro__75E3EFCF5790DEAC")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
