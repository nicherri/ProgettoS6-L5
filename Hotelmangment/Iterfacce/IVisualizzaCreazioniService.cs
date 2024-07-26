using Hotel.Models;

namespace Project.Services.Management
{
    public interface IVisualizzaCreazioniService
    {
        Task<List<Camera>> GetAllCamereAsync();
        Task<List<Cliente>> GetAllClientiAsync();
        Task<List<Prenotazione>> GetAllPrenotazioniAsync();
    }
}
