using Hotelmangment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Project.Controllers
{
    [Authorize]
    public class ServiziAggiuntiviController : Controller
    {
        private readonly IAddServiziAgg _addServiziAggService;

        public ServiziAggiuntiviController(IAddServiziAgg addServiziAggService)
        {
            _addServiziAggService = addServiziAggService;
        }

        public IActionResult AddServizioAgg(int idPrenotazione)
        {
            var viewModel = new AddServizioAggViewModel
            {
                IdPrenotazione = idPrenotazione
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddServizioAgg(AddServizioAggViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var servizioAgg = new PrenotazioneServizi
                    {
                        PrenotazioneId = model.IdPrenotazione,
                        ServizioId = model.IdServizioAgg,
                        Data = model.Data,
                        Quantita = model.Quantita,
                        Prezzo = model.Prezzo
                    };

                    await _addServiziAggService.AddServizioAggAsync(servizioAgg);
                    return RedirectToAction("VisualizzaPrenotazioni", "Visualizzazioni");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Errore durante l'aggiunta del servizio aggiuntivo.");
                    // Log the exception if needed
                }
            }

            return View(model);
        }
    }
}
