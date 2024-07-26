using Hotel.Models;
using Project.Services.Management;
using System.Data.SqlClient;

public class VisualizzaCreazioniService : IVisualizzaCreazioniService
{
    private readonly string _connectionString;
    private readonly ILogger<VisualizzaCreazioniService> _logger;

    public VisualizzaCreazioniService(IConfiguration configuration, ILogger<VisualizzaCreazioniService> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }

    public async Task<List<Camera>> GetAllCamereAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Id, Descrizione, PostoLetto, TipologiaCameraId, Prezzo FROM Camera", connection);
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                var camere = new List<Camera>();
                while (await reader.ReadAsync())
                {
                    camere.Add(new Camera
                    {
                        Id = reader.GetInt32(0),
                        Descrizione = reader.GetString(1),
                        PostoLetto = reader.GetInt32(2),
                        TipologiaCameraId = reader.GetInt32(3),
                        Prezzo = reader.GetDecimal(4)
                    });
                }
                return camere;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero delle camere.");
            throw;
        }
    }

    public async Task<List<Cliente>> GetAllClientiAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Id, CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare FROM Cliente", connection);
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                var clienti = new List<Cliente>();
                while (await reader.ReadAsync())
                {
                    clienti.Add(new Cliente
                    {
                        Id = reader.GetInt32(0),
                        CodiceFiscale = reader.GetString(1),
                        Cognome = reader.GetString(2),
                        Nome = reader.GetString(3),
                        Citta = reader.GetString(4),
                        Provincia = reader.GetString(5),
                        Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Telefono = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Cellulare = reader.IsDBNull(8) ? null : reader.GetString(8)
                    });
                }
                return clienti;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero dei clienti.");
            throw;
        }
    }

    public async Task<List<Prenotazione>> GetAllPrenotazioniAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Id, ClienteId, CameraId, DataPrenotazione, NumeroProgressivo, Anno, Dal, Al, CaparraConfirmatoria, PrezzoTariffa, DettagliSoggiornoId, ImmagineCover, TipologiaCameraId FROM Prenotazione", connection);
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
            _logger.LogError(ex, "Errore durante il recupero delle prenotazioni.");
            throw;
        }
    }
}
