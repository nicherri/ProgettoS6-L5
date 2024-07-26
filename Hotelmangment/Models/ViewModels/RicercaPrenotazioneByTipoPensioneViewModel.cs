using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.ViewModels
{
    public class RicercaPrenotazioneByTipoPensioneViewModel
    {
        [Required]
        public string TipoPensione { get; set; }
    }
}
