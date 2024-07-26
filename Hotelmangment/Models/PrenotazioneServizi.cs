using Hotel.Models;

public class PrenotazioneServizi
{
    public int Id { get; set; }
    public int PrenotazioneId { get; set; }
    public int ServizioId { get; set; }
    public DateTime Data { get; set; }
    public int Quantita { get; set; }
    public decimal Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Prenotazione Prenotazione { get; set; }
    public Servizio Servizio { get; set; }
    public Cliente Cliente { get; set; }
}
