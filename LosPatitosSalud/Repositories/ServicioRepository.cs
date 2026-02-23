using Microsoft.EntityFrameworkCore;
using LosPatitosSalud.Data;
using LosPatitosSalud.Models;

namespace LosPatitosSalud.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AppDbContext _contexto;

        public ServicioRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Servicio>> ObtenerTodosAsync()
        {
            return await _contexto.Servicios.ToListAsync();
        }

        public async Task<List<Servicio>> ObtenerActivosAsync()
        {
            return await _contexto.Servicios
                .Where(s => s.Estado == true)
                .ToListAsync();
        }

        public async Task<Servicio?> ObtenerPorIdAsync(int id)
        {
            return await _contexto.Servicios.FindAsync(id);
        }

        public async Task AgregarAsync(Servicio servicio)
        {
            _contexto.Servicios.Add(servicio);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Servicio servicio)
        {
            _contexto.Servicios.Update(servicio);
            await _contexto.SaveChangesAsync();
        }
    }
}
