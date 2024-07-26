using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Servizio
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Prezzo { get; set; }
    }
}
