using Hotel.Models;
using System.Data.SqlClient;

public class CreazioneService : ICreazioneService
{
    private readonly string _connectionString;
    private readonly ILogger<CreazioneService> _logger;

    public CreazioneService(IConfiguration configuration, ILogger<CreazioneService> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }

    public async Task<Cliente> CreazioneClienteAsync(Cliente cliente)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Cliente (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) OUTPUT INSERTED.Id VALUES (@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)", connection);
                command.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@Citta", cliente.Citta);
                command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                command.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare ?? (object)DBNull.Value);

                await connection.OpenAsync();
                cliente.Id = (int)await command.ExecuteScalarAsync();
                return cliente;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la creazione del cliente.");
            throw;
        }
    }

    public async Task<Camera> CreazioneCameraAsync(Camera camera)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Camera (Descrizione, PostoLetto, TipologiaCameraId, Prezzo) OUTPUT INSERTED.Id VALUES (@Descrizione, @PostoLetto, @TipologiaCameraId, @Prezzo)", connection);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                command.Parameters.AddWithValue("@PostoLetto", camera.PostoLetto);
                command.Parameters.AddWithValue("@TipologiaCameraId", camera.TipologiaCameraId);
                command.Parameters.AddWithValue("@Prezzo", camera.Prezzo);

                await connection.OpenAsync();
                camera.Id = (int)await command.ExecuteScalarAsync();
                return camera;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la creazione della camera.");
            throw;
        }
    }

    public async Task<Prenotazione> CreazionePrenotazioneAsync(Prenotazione prenotazione)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Prenotazione (ClienteId, CameraId, DataPrenotazione, NumeroProgressivo, Anno, Dal, Al, CaparraConfirmatoria, PrezzoTariffa, DettagliSoggiornoId, ImmagineCover, TipologiaCameraId) OUTPUT INSERTED.Id VALUES (@ClienteId, @CameraId, @DataPrenotazione, @NumeroProgressivo, @Anno, @Dal, @Al, @CaparraConfirmatoria, @PrezzoTariffa, @DettagliSoggiornoId, @ImmagineCover, @TipologiaCameraId)", connection);
                command.Parameters.AddWithValue("@ClienteId", prenotazione.ClienteId);
                command.Parameters.AddWithValue("@CameraId", prenotazione.CameraId);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@NumeroProgressivo", prenotazione.NumeroProgressivo);
                command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                command.Parameters.AddWithValue("@Dal", prenotazione.Dal);
                command.Parameters.AddWithValue("@Al", prenotazione.Al);
                command.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                command.Parameters.AddWithValue("@PrezzoTariffa", prenotazione.PrezzoTariffa);
                command.Parameters.AddWithValue("@DettagliSoggiornoId", prenotazione.DettagliSoggiornoId);
                command.Parameters.AddWithValue("@ImmagineCover", prenotazione.ImmagineCover ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TipologiaCameraId", prenotazione.TipologiaCameraId);

                await connection.OpenAsync();
                prenotazione.Id = (int)await command.ExecuteScalarAsync();
                return prenotazione;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la creazione della prenotazione.");
            throw;
        }
    }
}
