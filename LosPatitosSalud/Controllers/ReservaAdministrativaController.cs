using Microsoft.AspNetCore.Mvc;
using LosPatitosSalud.Services;

namespace LosPatitosSalud.Controllers
{
    public class ReservaAdministrativaController : Controller
    {
        private readonly ICitaService _servicioCita;

        public ReservaAdministrativaController(ICitaService servicioCita)
        {
            _servicioCita = servicioCita;
        }

        public async Task<IActionResult> Listar(int? idServicio)
        {
            var citas = idServicio.HasValue
                ? await _servicioCita.ObtenerPorIdServicioAsync(idServicio.Value)
                : await _servicioCita.ObtenerTodasAsync();

            ViewBag.IdServicioFiltro = idServicio;
            return View(citas);
        }
    }
}
