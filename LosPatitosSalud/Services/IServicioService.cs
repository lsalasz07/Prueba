using LosPatitosSalud.Models;

namespace LosPatitosSalud.Services
{
    public interface IServicioService
    {
        Task<List<Servicio>> ObtenerTodosAsync();
        Task<List<Servicio>> ObtenerActivosAsync();
        Task<Servicio?> ObtenerPorIdAsync(int id);
        Task RegistrarAsync(Servicio servicio);
        Task EditarAsync(Servicio servicio);
    }
}
