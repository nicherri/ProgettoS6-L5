using Hotel.Models;
using Project.Services.Management;
using System.Data.SqlClient;

public class RicercheService : IRicercheService
{
    private readonly string _connectionString;
    private readonly ILogger<RicercheService> _logger;

    public RicercheService(IConfiguration configuration, ILogger<RicercheService> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }

    public async Task<List<Prenotazione>> GetPrenotazioniByCFAsync(string codiceFiscale)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT p.* FROM Prenotazione p INNER JOIN Cliente c ON p.ClienteId = c.Id WHERE c.CodiceFiscale = @CodiceFiscale", connection);
                command.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                var prenotazioni = new List<Prenotazione>();
                while (await reader.ReadAsync())
                {
                    prenotazioni.Add(new Prenotazione
                    {
                        Id = reader.GetInt32(0),
                        ClienteId = reader.GetInt32(1),
                        CameraId = reader.GetInt32(2),
                        DataPrenotazione = reader.GetDateTime(3),
                        NumeroProgressivo = reader.GetInt32(4),
                        Anno = reader.GetInt32(5),
                        Dal = reader.GetDateTime(6),
                        Al = reader.GetDateTime(7),
                        CaparraConfirmatoria = reader.GetDecimal(8),
                        PrezzoTariffa = reader.GetDecimal(9),
                        DettagliSoggiornoId = reader.GetInt32(10),
                        ImmagineCover = reader.IsDBNull(11) ? null : reader.GetString(11),
                        TipologiaCameraId = reader.GetInt32(12)
                    });
                }
                return prenotazioni;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero delle prenotazioni per codice fiscale.");
            throw;
        }
    }

    public async Task<List<Prenotazione>> GetPrenotazioniByTipoPensioneAsync(string tipoPensione)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT p.* FROM Prenotazione p INNER JOIN DettagliSoggiorno ds ON p.DettagliSoggiornoId = ds.Id WHERE ds.Nome = @TipoPensione", connection);
                command.Parameters.AddWithValue("@TipoPensione", tipoPensione);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                var prenotazioni = new List<Prenotazione>();
                while (await reader.ReadAsync())
                {
                    prenotazioni.Add(new Prenotazione
                    {
                        Id = reader.GetInt32(0),
                        ClienteId = reader.GetInt32(1),
                        CameraId = reader.GetInt32(2),
                        DataPrenotazione = reader.GetDateTime(3),
                        NumeroProgressivo = reader.GetInt32(4),
                        Anno = reader.GetInt32(5),
                        Dal = reader.GetDateTime(6),
                        Al = reader.GetDateTime(7),
                        CaparraConfirmatoria = reader.GetDecimal(8),
                        PrezzoTariffa = reader.GetDecimal(9),
                        DettagliSoggiornoId = reader.GetInt32(10),
                        ImmagineCover = reader.IsDBNull(11) ? null : reader.GetString(11),
                        TipologiaCameraId = reader.GetInt32(12)
                    });
                }
                return prenotazioni;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero delle prenotazioni per tipo pensione.");
            throw;
        }
    }
}
