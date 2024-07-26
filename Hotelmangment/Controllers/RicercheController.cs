﻿using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Management;

namespace Project.Controllers
{
    [Authorize]
    [Route("Ricerche/[controller]")]
    public class RicercheController : Controller
    {
        private readonly IRicercheService _ricercheService;

        public RicercheController(IRicercheService ricercheService)
        {
            _ricercheService = ricercheService;
        }

        [HttpGet("RicercaByCF")]
        public IActionResult RicercaByCF()
        {
            return View();
        }

        [HttpPost("RicercaByCF")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RicercaByCF(string codiceFiscale)
        {
            if (string.IsNullOrWhiteSpace(codiceFiscale))
            {
                ModelState.AddModelError("", "Il codice fiscale non può essere nullo o vuoto.");
                return View();
            }

            try
            {
                var prenotazioni = await _ricercheService.GetPrenotazioniByCFAsync(codiceFiscale);

                if (prenotazioni != null && prenotazioni.Any())
                {
                    return Json(new { success = true, redirectUrl = Url.Action("RisultatiByCF", new { codiceFiscale }) });
                }
                else
                {
                    ModelState.AddModelError("", "Nessuna prenotazione trovata per il codice fiscale fornito.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Errore interno del server. Si prega di riprovare più tardi.");
            }
        }

        [HttpGet("RisultatiByCF")]
        public async Task<IActionResult> RisultatiByCF(string codiceFiscale)
        {
            if (string.IsNullOrWhiteSpace(codiceFiscale))
            {
                return RedirectToAction("RicercaByCF");
            }

            try
            {
                var prenotazioni = await _ricercheService.GetPrenotazioniByCFAsync(codiceFiscale);

                if (prenotazioni == null || !prenotazioni.Any())
                {
                    ViewBag.Message = "Nessuna prenotazione trovata per il codice fiscale fornito.";
                }

                return View(prenotazioni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Errore interno del server. Si prega di riprovare più tardi.");
            }
        }

        [HttpGet("RicercaByTipoPensione")]
        public IActionResult RicercaByTipoPensione()
        {
            return View();
        }

        [HttpPost("RicercaByTipoPensione")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RicercaByTipoPensione(RicercaPrenotazioneByTipoPensioneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var prenotazioni = await _ricercheService.GetPrenotazioniByTipoPensioneAsync(model.TipoPensione);

                if (prenotazioni != null && prenotazioni.Any())
                {
                    return Json(new { success = true, redirectUrl = Url.Action("RisultatiByTipoPensione", new { tipoPensione = model.TipoPensione }) });
                }
                else
                {
                    ModelState.AddModelError("", "Nessuna prenotazione trovata per il tipo di pensione selezionato.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Errore interno del server. Si prega di riprovare più tardi.");
            }
        }

        [HttpGet("RisultatiByTipoPensione")]
        public async Task<IActionResult> RisultatiByTipoPensione(string tipoPensione)
        {
            if (string.IsNullOrWhiteSpace(tipoPensione))
            {
                return RedirectToAction("RicercaByTipoPensione");
            }

            try
            {
                var prenotazioni = await _ricercheService.GetPrenotazioniByTipoPensioneAsync(tipoPensione);

                if (prenotazioni == null || !prenotazioni.Any())
                {
                    ViewBag.Message = "Nessuna prenotazione trovata per il tipo di pensione selezionato.";
                }

                return View(prenotazioni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Errore interno del server. Si prega di riprovare più tardi.");
            }
        }
    }
}
