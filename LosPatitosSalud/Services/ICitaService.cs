using LosPatitosSalud.Models;

namespace LosPatitosSalud.Services
{
    public interface ICitaService
    {
        Task<List<Cita>> ObtenerTodasAsync();
        Task<List<Cita>> ObtenerPorIdServicioAsync(int idServicio);
        Task<Cita?> ObtenerPorIdAsync(int id);
        Task<bool> ServicioYaTieneReservaAsync(int idServicio);
        Task ReservarAsync(Cita cita, Servicio servicio);
    }
}