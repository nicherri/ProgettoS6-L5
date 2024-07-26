using Hotel.Models;

public interface ICreazioneService
{
    Task<Cliente> CreazioneClienteAsync(Cliente cliente);
    Task<Camera> CreazioneCameraAsync(Camera camera);
    Task<Prenotazione> CreazionePrenotazioneAsync(Prenotazione prenotazione);
}
