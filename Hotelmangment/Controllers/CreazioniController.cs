using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Authorize]
    public class CreazioniController : Controller
    {
        private readonly ICreazioneService _creazioneService;
        private readonly ILogger<CreazioniController> _logger;

        public CreazioniController(ICreazioneService creazioneService, ILogger<CreazioniController> logger)
        {
            _creazioneService = creazioneService;
            _logger = logger;
        }

        public IActionResult CreazioneCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreazioneCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            try
            {
                await _creazioneService.CreazioneClienteAsync(cliente);
                return RedirectToAction("Management", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione del cliente.");
                ModelState.AddModelError(string.Empty, "Si è verificato un errore. Riprova più tardi.");
                return View(cliente);
            }
        }

        public IActionResult CreazioneCamera()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreazioneCamera(Camera camera)
        {
            if (!ModelState.IsValid)
            {
                return View(camera);
            }

            try
            {
                await _creazioneService.CreazioneCameraAsync(camera);
                return RedirectToAction("Management", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione della camera.");
                ModelState.AddModelError(string.Empty, "Si è verificato un errore. Riprova più tardi.");
                return View(camera);
            }
        }

        public IActionResult CreazionePrenotazione()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreazionePrenotazione(Prenotazione prenotazione)
        {
            if (!ModelState.IsValid)
            {
                return View(prenotazione);
            }

            try
            {
                await _creazioneService.CreazionePrenotazioneAsync(prenotazione);
                return RedirectToAction("Management", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione della prenotazione.");
                ModelState.AddModelError(string.Empty, "Si è verificato un errore. Riprova più tardi.");
                return View(prenotazione);
            }
        }
    }
}
