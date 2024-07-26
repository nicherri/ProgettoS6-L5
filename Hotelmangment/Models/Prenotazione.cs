using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int CameraId { get; set; }

        [Required]
        public DateTime DataPrenotazione { get; set; }

        [Required]
        public int NumeroProgressivo { get; set; }

        [Required]
        public int Anno { get; set; }

        [Required]
        public DateTime Dal { get; set; }

        [Required]
        public DateTime Al { get; set; }

        [Required]
        public decimal CaparraConfirmatoria { get; set; }

        [Required]
        public decimal PrezzoTariffa { get; set; }

        [Required]
        public int DettagliSoggiornoId { get; set; }

        [Required]
        [StringLength(255)]
        public string ImmagineCover { get; set; }

        [Required]
        public int TipologiaCameraId { get; set; }

        public Cliente Cliente { get; set; }
        public Camera Camera { get; set; }
        public DettagliSoggiorno DettagliSoggiorno { get; set; }
        public TipologiaCamera TipologiaCamera { get; set; }
        public ICollection<PrenotazioneServizi> PrenotazioneServizi { get; set; }

        public decimal CalcolaPrezzoTotale()
        {
            decimal prezzoCamera = Camera.Prezzo;
            decimal prezzoDettaglioSoggiorno = DettagliSoggiorno.Prezzo;
            decimal prezzoServiziAggiuntivi = 0;

            foreach (var servizio in PrenotazioneServizi)
            {
                prezzoServiziAggiuntivi += servizio.Prezzo * servizio.Quantita;
            }

            return prezzoCamera + prezzoDettaglioSoggiorno + prezzoServiziAggiuntivi;
        }
    }
}
