using Hotel.Models;


namespace Project.Services.Management
{
    public interface IRicercheService
    {
        Task<List<Prenotazione>> GetPrenotazioniByCFAsync(string codiceFiscale);
        Task<List<Prenotazione>> GetPrenotazioniByTipoPensioneAsync(string tipoPensione);
    }
}
