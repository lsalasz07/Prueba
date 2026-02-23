using LosPatitosSalud.Models;
using LosPatitosSalud.Repositories;

namespace LosPatitosSalud.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _repositorio;

        public CitaService(ICitaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Cita>> ObtenerTodasAsync()
            => await _repositorio.ObtenerTodasAsync();

        public async Task<List<Cita>> ObtenerPorIdServicioAsync(int idServicio)
            => await _repositorio.ObtenerPorIdServicioAsync(idServicio);

        public async Task<Cita?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<bool> ServicioYaTieneReservaAsync(int idServicio)
        {
            var citas = await _repositorio.ObtenerPorIdServicioAsync(idServicio);
            return citas.Any();
        }

        public async Task ReservarAsync(Cita cita, Servicio servicio)
        {
            cita.MontoTotal = (servicio.Monto * servicio.IVA) + servicio.Monto;
            cita.FechaDeRegistro = DateTime.Now;
            cita.IdServicio = servicio.Id;
            await _repositorio.AgregarAsync(cita);
        }
    }
}