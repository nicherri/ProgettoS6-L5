using Hotel.Models; // Assicurati che il namespace sia corretto e punti alle tue entità
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data // Assicurati che il namespace sia corretto e corrisponda alla struttura del tuo progetto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }
        // Aggiungi DbSet per le altre entità se necessario

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurazioni aggiuntive se necessarie
        }
    }
}
