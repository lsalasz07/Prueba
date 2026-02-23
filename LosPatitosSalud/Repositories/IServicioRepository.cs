using LosPatitosSalud.Models;

namespace LosPatitosSalud.Repositories
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> ObtenerTodosAsync();
        Task<List<Servicio>> ObtenerActivosAsync();
        Task<Servicio?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Servicio servicio);
        Task ActualizarAsync(Servicio servicio);
    }
}
