using Hotel.Utilities;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [StringLength(16, MinimumLength = 16, ErrorMessage = "Il Codice Fiscale deve essere di 16 caratteri.")]
    public string CodiceFiscale { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Il cognome non può superare i 50 caratteri.")]
    public string Cognome { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Il nome non può superare i 50 caratteri.")]
    public string Nome { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "La città non può superare i 50 caratteri.")]
    public string Citta { get; set; }

    [Required]
    [StringLength(2, ErrorMessage = "La provincia deve essere di 2 caratteri.")]
    public string Provincia { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Telefono { get; set; }
    public string Cellulare { get; set; }

    public void GeneraCodiceFiscale()
    {
        this.CodiceFiscale = CodiceFiscaleHelper.CalcolaCodiceFiscale(this.Nome, this.Cognome, DateTime.Now, this.Citta, "M");
    }
}
