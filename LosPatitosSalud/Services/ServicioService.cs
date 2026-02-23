using LosPatitosSalud.Models;
using LosPatitosSalud.Repositories;

namespace LosPatitosSalud.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repositorio;

        public ServicioService(IServicioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Servicio>> ObtenerTodosAsync()
            => await _repositorio.ObtenerTodosAsync();

        public async Task<List<Servicio>> ObtenerActivosAsync()
            => await _repositorio.ObtenerActivosAsync();

        public async Task<Servicio?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task RegistrarAsync(Servicio servicio)
        {
            servicio.FechaDeRegistro = DateTime.Now;
            servicio.FechaDeModificacion = null;
            await _repositorio.AgregarAsync(servicio);
        }

        public async Task EditarAsync(Servicio servicio)
        {
            servicio.FechaDeModificacion = DateTime.Now;
            await _repositorio.ActualizarAsync(servicio);
        }
    }
}
