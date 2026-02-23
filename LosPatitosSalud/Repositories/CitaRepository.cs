using Microsoft.EntityFrameworkCore;
using LosPatitosSalud.Data;
using LosPatitosSalud.Models;

namespace LosPatitosSalud.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly AppDbContext _contexto;

        public CitaRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Cita>> ObtenerTodasAsync()
        {
            return await _contexto.Citas
                .Include(c => c.Servicio)
                .ToListAsync();
        }

        public async Task<List<Cita>> ObtenerPorIdServicioAsync(int idServicio)
        {
            return await _contexto.Citas
                .Include(c => c.Servicio)
                .Where(c => c.IdServicio == idServicio)
                .ToListAsync();
        }

        public async Task<Cita?> ObtenerPorIdAsync(int id)
        {
            return await _contexto.Citas
                .Include(c => c.Servicio)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AgregarAsync(Cita cita)
        {
            _contexto.Citas.Add(cita);
            await _contexto.SaveChangesAsync();
        }
    }
}
