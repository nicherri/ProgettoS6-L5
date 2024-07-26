namespace Hotelmangment.Models
{
    public class AddServizioAggViewModel
    {
        public int IdPrenotazione { get; set; }
        public int IdServizioAgg { get; set; }
        public DateTime Data { get; set; }

        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
    }
}
