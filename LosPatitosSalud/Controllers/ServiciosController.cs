using Microsoft.AspNetCore.Mvc;
using LosPatitosSalud.Models;
using LosPatitosSalud.Services;

namespace LosPatitosSalud.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IServicioService _servicioServicio;
        private readonly ICitaService _servicioCita;

        public ServiciosController(IServicioService servicioServicio, ICitaService servicioCita)
        {
            _servicioServicio = servicioServicio;
            _servicioCita = servicioCita;
        }

        public async Task<IActionResult> Listar()
        {
            var servicios = await _servicioServicio.ObtenerTodosAsync();
            return View(servicios);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(Servicio servicio)
        {
            if (!ModelState.IsValid)
                return View(servicio);

            await _servicioServicio.RegistrarAsync(servicio);
            TempData["Exito"] = "Servicio registrado exitosamente.";
            return RedirectToAction(nameof(Listar));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var servicio = await _servicioServicio.ObtenerPorIdAsync(id);
            if (servicio == null) return NotFound();
            return View(servicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Servicio servicio)
        {
            if (!ModelState.IsValid)
                return View(servicio);

            await _servicioServicio.EditarAsync(servicio);
            TempData["Exito"] = "Servicio actualizado exitosamente.";
            return RedirectToAction(nameof(Listar));
        }

        public async Task<IActionResult> VerCitas(int id)
        {
            var citas = await _servicioCita.ObtenerPorIdServicioAsync(id);
            ViewBag.IdServicio = id;
            return View(citas);
        }
    }
}
