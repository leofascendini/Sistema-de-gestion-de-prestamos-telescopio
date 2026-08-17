using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.AccesoDatos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {

        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //ACA SE PONE TODA LA CONFIG DE LAS TABLAS
            //RESTRICCIONES, RELACIONES, ETC

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<ObservacionAstro>()
                .Property(o => o.ResultadoIA)
                .HasMaxLength(300);

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.estado)
                .HasConversion<string>();

            modelBuilder.Entity<Montura>()
                .Property(m => m.tipoMontura)
                .HasConversion<string>();
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Telescopio)
                .WithMany()
                .HasForeignKey(p => p.TelescopioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Montura)
                .WithMany()
                .HasForeignKey(p => p.MonturaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Camara)
                .WithMany()
                .HasForeignKey(p => p.CamaraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.estado)
                .HasConversion<string>();

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Ocular)
                .WithMany()
                .HasForeignKey(p => p.OcularId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Auditoria>()
                .HasKey(a => a.AuditoriaPrestamoId);

            modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.UsuarioCoordinador)
                .WithMany()
                .HasForeignKey(a => a.UsuarioCoordinadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.Prestamo)
                .WithMany()
                .HasForeignKey(a => a.PrestamoId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Camara> Camaras { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Montura> Monturas { get; set; }
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }
        public DbSet<ObservacionAstro> ObservacionAstros { get; set; }
        public DbSet<Ocular> Oculares { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Telescopio> Telescopios { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }



    }
}
