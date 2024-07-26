namespace Hotel.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public int PostoLetto { get; set; }
        public int TipologiaCameraId { get; set; }
        public decimal Prezzo { get; set; }
        public TipologiaCamera TipologiaCamera { get; set; }
    }
}
