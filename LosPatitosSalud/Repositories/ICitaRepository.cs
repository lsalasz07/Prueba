using LosPatitosSalud.Models;

namespace LosPatitosSalud.Repositories
{
    public interface ICitaRepository
    {
        Task<List<Cita>> ObtenerTodasAsync();
        Task<List<Cita>> ObtenerPorIdServicioAsync(int idServicio);
        Task<Cita?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cita cita);
    }
}
