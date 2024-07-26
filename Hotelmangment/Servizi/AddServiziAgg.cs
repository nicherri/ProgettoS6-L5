using System.Data.SqlClient;

public class AddServiziAgg : IAddServiziAgg
{
    private readonly string _connectionString;
    private readonly ILogger<AddServiziAgg> _logger;

    public AddServiziAgg(IConfiguration configuration, ILogger<AddServiziAgg> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }

    public async Task<PrenotazioneServizi> AddServizioAggAsync(PrenotazioneServizi prenotazioneServizi)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO PrenotazioneServizi (PrenotazioneId, ServizioId, Data, Quantita, Prezzo, ClienteId) OUTPUT INSERTED.Id VALUES (@PrenotazioneId, @ServizioId, @Data, @Quantita, @Prezzo, @ClienteId)", connection);
                command.Parameters.AddWithValue("@PrenotazioneId", prenotazioneServizi.PrenotazioneId);
                command.Parameters.AddWithValue("@ServizioId", prenotazioneServizi.ServizioId);
                command.Parameters.AddWithValue("@Data", prenotazioneServizi.Data);
                command.Parameters.AddWithValue("@Quantita", prenotazioneServizi.Quantita);
                command.Parameters.AddWithValue("@Prezzo", prenotazioneServizi.Prezzo);
                command.Parameters.AddWithValue("@ClienteId", prenotazioneServizi.ClienteId);

                await connection.OpenAsync();
                prenotazioneServizi.Id = (int)await command.ExecuteScalarAsync();
                return prenotazioneServizi;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'aggiunta del servizio aggiuntivo.");
            throw;
        }
    }
}
