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

        public virtual DbSet<Aportacion> Aportaciones { get; set; }

        public virtual DbSet<Socio> Socios { get; set; }
        public virtual DbSet<Beneficiario> Beneficiarios { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<CategoriaAsociado> CategoriasAsociados { get; set; }
        public virtual DbSet<Credito> Creditos { get; set; }
        public virtual DbSet<Cuota> Cuota { get; set; }
        public virtual DbSet<Deduccion> Deducciones { get; set; }
        public virtual DbSet<DeduccionCredito> DeduccionesCreditos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoCredito> EstadosCreditos { get; set; }
        public virtual DbSet<EstadoCuota> EstadoCuota { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<PermisoUsuario> PermisoUsuarios { get; set; }
        public virtual DbSet<TipoCuota> TiposCuotas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<RegistroUsuario> RegistrosUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Conexion de Hamilton
                // optionsBuilder.UseSqlServer("Server = DESKTOP-9NPOF6R\\SQLEXPRESS; Database = AzocDb; Trusted_Connection = True; ");

                // Conexion de Jonathan
                // optionsBuilder.UseSqlServer("Server=DESKTOP-6AAJJ4I\\SQLEXPRESS; Database=AzocDb; Trusted_Connection=True;");

                // Conexion de Jonathan 2
                optionsBuilder.UseSqlServer("Server=LAPTOP-2NF0HEH\\SQLEXPRESS; Database=AzocDb; Trusted_Connection=True;");

                // Conexion de Walter
                // optionsBuilder.UseSqlServer("Server=WALTER\\SQLEXPRESS; Database=AzocDb; Trusted_Connection=True;");

                // Conexion de David
                // optionsBuilder.UseSqlServer("Server=MELGAR\\MSSQLSERVER19; Database=AzocDb; Trusted_Connection=True;");

                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.HasKey(e => e.SocioId)
                .HasName("PK__Socio__165D08BAAABAF47D");

                entity.ToTable("Socio");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ingreso).HasColumnType("date");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacimiento).HasColumnType("date");

                entity.Property(e => e.Nit)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Papellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PApellido");

                entity.Property(e => e.Pnombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PNombre");

                entity.Property(e => e.Retiro).HasColumnType("date");

                entity.Property(e => e.Sapellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SApellido");

                entity.Property(e => e.Snombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SNombre");

                entity.Property(e => e.Tapellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TApellido");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tnombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TNombre");

                entity.HasOne(d => d.CategoriaAsociado)
                    .WithMany(p => p.Socios)
                    .HasForeignKey(d => d.CategoriaAsociadoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Socio_CategoriaAsociado");
            });

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
                    .HasConstraintName("FK_Aportacion_Socio");
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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Beneficiario_Socio");
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
                entity.HasKey(e => e.CreditoId)
                .HasName("PK__Credito__4FE406DDC4D852B6");

                entity.ToTable("Credito");

                entity.Property(e => e.TasaInteres).HasColumnType("decimal")
                .IsRequired();

                entity.Property(e => e.Aprobacion).HasColumnType("date");

                entity.Property(e => e.Inicio).HasColumnType("date")
                .IsRequired();

                entity.Property(e => e.Monto).HasColumnType("money")
                .IsRequired();

                entity.Property(e => e.Plazo).HasColumnType("int")
                .IsRequired();

                entity.Property(e => e.Codigo).HasColumnType("int")
                .IsRequired();

                entity.HasOne(d => d.Socio)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.SocioId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Socio_Credito");

                entity.HasOne(d => d.EstadoCredito)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.EstadoCreditoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Credito_EstadoCredito");
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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Cuota_Credito");

                entity.HasOne(d => d.EstadoCuota)
                    .WithMany(p => p.Cuotas)
                    .HasForeignKey(d => d.EstadoCuotaId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Cuota_EstadoCuota");

                entity.HasOne(d => d.TipoCuota)
                    .WithMany(p => p.Cuota)
                    .HasForeignKey(d => d.TipoCuotaId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Cuota_TipoCuota");
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

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.Credito)
                    .WithMany(p => p.DeduccionesCreditos)
                    .HasForeignKey(d => d.CreditoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Deduccion__Credi__5AEE82B9");

                entity.HasOne(d => d.Deduccion)
                    .WithMany(p => p.DeduccionCreditos)
                    .HasForeignKey(d => d.DeduccionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DeduccionCredito_Deduccion");
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Empleado_Cargo");
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PermisoUsuario_Permiso");

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
                    .OnDelete(DeleteBehavior.Cascade)
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RegistroUsuario_Registro");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RegistroUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RegistroUsuario_Usuario");
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
