using Microsoft.EntityFrameworkCore;
using LosPatitosSalud.Models;

namespace LosPatitosSalud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opciones)
            : base(opciones) { }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}
