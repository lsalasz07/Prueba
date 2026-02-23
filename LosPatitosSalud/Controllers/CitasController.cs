using Microsoft.AspNetCore.Mvc;
using LosPatitosSalud.Models;
using LosPatitosSalud.Services;

namespace LosPatitosSalud.Controllers
{
    public class CitasController : Controller
    {
        private readonly ICitaService _servicioCita;
        private readonly IServicioService _servicioServicio;

        public CitasController(ICitaService servicioCita, IServicioService servicioServicio)
        {
            _servicioCita = servicioCita;
            _servicioServicio = servicioServicio;
        }

        public async Task<IActionResult> Listar(int? idCita)
        {
            if (idCita.HasValue)
            {
                var cita = await _servicioCita.ObtenerPorIdAsync(idCita.Value);
                if (cita == null)
                {
                    TempData["Error"] = "Estimado usuario, no se ha encontrado la cita, favor realice una.";
                }
                else
                {
                    return RedirectToAction(nameof(DetallesCita), new { id = cita.Id });
                }
            }

            var servicios = await _servicioServicio.ObtenerActivosAsync();
            return View(servicios);
        }

        public async Task<IActionResult> Reservar(int id)
        {
            var servicio = await _servicioServicio.ObtenerPorIdAsync(id);
            if (servicio == null || !servicio.Estado) return NotFound();

            bool yaReservado = await _servicioCita.ServicioYaTieneReservaAsync(id);
            if (yaReservado)
            {
                TempData["Error"] = "Este servicio ya cuenta con una reserva activa y no puede reservarse nuevamente.";
                return RedirectToAction(nameof(Listar));
            }

            var cita = new Cita { IdServicio = id };
            ViewBag.Servicio = servicio;
            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservar(Cita cita)
        {
            var servicio = await _servicioServicio.ObtenerPorIdAsync(cita.IdServicio);
            if (servicio == null) return NotFound();

            bool yaReservado = await _servicioCita.ServicioYaTieneReservaAsync(cita.IdServicio);
            if (yaReservado)
            {
                TempData["Error"] = "Este servicio ya cuenta con una reserva activa y no puede reservarse nuevamente.";
                return RedirectToAction(nameof(Listar));
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Servicio = servicio;
                return View(cita);
            }

            await _servicioCita.ReservarAsync(cita, servicio);
            TempData["Exito"] = "Cita reservada exitosamente.";
            return RedirectToAction(nameof(DetallesCita), new { id = cita.Id });
        }

        public async Task<IActionResult> DetallesCita(int id)
        {
            var cita = await _servicioCita.ObtenerPorIdAsync(id);
            if (cita == null) return NotFound();
            return View(cita);
        }
    }
}