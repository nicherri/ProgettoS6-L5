using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.ViewModels
{
    public class RicercaPrenotazioneByCFViewModel
    {
        [Required]
        public string CodiceFiscale { get; set; }
    }
}
