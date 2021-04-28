using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Finz__Frontend_.Models
{
    public partial class FinzContext : DbContext
    {
        public FinzContext()
        {
        }

        public FinzContext(DbContextOptions<FinzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ahorros> Ahorros { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Dinero> Dinero { get; set; }
        public virtual DbSet<Gastos> Gastos { get; set; }
        public virtual DbSet<GastosFijos> GastosFijos { get; set; }
        public virtual DbSet<Retos> Retos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BRAYAN-WINDOWS;Database=Finz;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ahorros>(entity =>
            {
                entity.HasKey(e => e.IdAhorros)
                    .HasName("PK__Ahorros__5049C455618EE4F6");

                entity.Property(e => e.IdAhorros).HasColumnName("ID_ahorros");

                entity.Property(e => e.AhorrosAcutales).HasColumnName("ahorros_acutales");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_Usuario")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Ahorros)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ahorros_Categorias");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ahorros)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ahorros_Usuario");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__02AA07854D19DB06");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dinero>(entity =>
            {
                entity.HasKey(e => e.IdDinero)
                    .HasName("PK__Dinero__CCC5EE72E804E9BD");

                entity.Property(e => e.IdDinero).HasColumnName("ID_Dinero");

                entity.Property(e => e.DineroActual).HasColumnName("dinero_actual");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_Usuario")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dinero)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dinero_Usuario");
            });

            modelBuilder.Entity<Gastos>(entity =>
            {
                entity.HasKey(e => e.IdGastos)
                    .HasName("PK__Gastos__DFBBF5CB559DBC91");

                entity.Property(e => e.IdGastos).HasColumnName("ID_Gastos");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fecha_fin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.Gastos1).HasColumnName("gastos");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_Usuario")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gastos__id_categ__32E0915F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gastos_Usuario");
            });

            modelBuilder.Entity<GastosFijos>(entity =>
            {
                entity.HasKey(e => e.IdGastoFijo)
                    .HasName("PK__Gastos_F__59E25574E7DBBB27");

                entity.ToTable("Gastos_Fijos");

                entity.Property(e => e.IdGastoFijo).HasColumnName("ID_Gasto_fijo");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_Usuario")
                    .HasMaxLength(450);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.GastosFijos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gastos_Fijos_Usuario");
            });

            modelBuilder.Entity<Retos>(entity =>
            {
                entity.HasKey(e => e.IdReto)
                    .HasName("PK__Retos__4450A46099E579A5");

                entity.Property(e => e.IdReto).HasColumnName("ID_Reto");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.FechaLimite)
                    .HasColumnName("fecha_limite")
                    .HasColumnType("date");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_Usuario")
                    .HasMaxLength(450);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Retos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Retos_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__DE4431C5398D5F32");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
