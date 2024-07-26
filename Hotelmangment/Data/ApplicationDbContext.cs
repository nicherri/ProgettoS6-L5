using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotelmangment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<DettagliSoggiorno> DettagliSoggiorni { get; set; }
        public DbSet<TipologiaCamera> TipologieCamere { get; set; }
        public DbSet<PrenotazioneServizi> PrenotazioneServizi { get; set; }
    }
}
