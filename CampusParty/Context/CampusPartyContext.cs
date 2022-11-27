using CampusParty.Models;
using Microsoft.EntityFrameworkCore;
using DevOne.Security.Cryptography.BCrypt;

namespace CampusParty.Context {
    public class CampusPartyContext : DbContext {

        public CampusPartyContext(DbContextOptions<CampusPartyContext> options) : base(options) {

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pabellon> Pabellones { get; set; }
        public DbSet<UsuarioEvento> UsuarioEventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Computador> Computadores { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<SoftwareEducativo> SoftwareEducativos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Sitio> Sitios { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Rol>().HasData(
                new Rol {
                    RolId = 1,
                    Nombre = "Admin",
                },
                new Rol {
                    RolId = 2,
                    Nombre = "User"
                }
            );

            modelBuilder.Entity<Ciudad>().HasData(
                new Ciudad {
                    CiudadId = 1,
                    Nombre = "Medellín",
                    NumeroHabitantes = 1000000,
                    NumeroUniversidades = 100
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario {
                     UsuarioId = 1,
                     NombreCompleto = "Admin",
                     Documento = "10001460",
                     Correo = "admin@gmail.com",
                     Contraseña = BCryptHelper.HashPassword("admin", BCryptHelper.GenerateSalt()),
                     FechaNacimiento = DateTime.Now,
                     Telefono = "777",
                     CiudadId = 1,
                     RolId = 1
                }
            );
        }
    }
}
