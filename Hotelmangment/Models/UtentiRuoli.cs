namespace Hotel.Models
{
    public class UtentiRuoli
    {
        public int IdUtenti { get; set; }
        public int IdRuolo { get; set; }
        public Utente Utente { get; set; }
        public Ruolo Ruolo { get; set; }
    }
}
