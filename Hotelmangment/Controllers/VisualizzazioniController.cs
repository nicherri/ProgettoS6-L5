using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Management;

namespace Project.Controllers
{
    [Authorize]
    public class VisualizzazioniController : Controller
    {
        private readonly IVisualizzaCreazioniService _visualizzaCreazioniService;

        public VisualizzazioniController(IVisualizzaCreazioniService visualizzaCreazioniService)
        {
            _visualizzaCreazioniService = visualizzaCreazioniService;
        }

        public async Task<IActionResult> VisualizzaPersone()
        {
            var persone = await _visualizzaCreazioniService.GetAllClientiAsync();
            return View(persone);
        }

        public async Task<IActionResult> VisualizzaCamere()
        {
            var camere = await _visualizzaCreazioniService.GetAllCamereAsync();
            return View(camere);
        }

        public async Task<IActionResult> VisualizzaPrenotazioni()
        {
            var prenotazioni = await _visualizzaCreazioniService.GetAllPrenotazioniAsync();
            return View(prenotazioni);
        }
    }
}
