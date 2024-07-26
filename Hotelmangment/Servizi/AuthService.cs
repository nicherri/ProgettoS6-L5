using Project.Services.Auth;
using System.Data.SqlClient;

public class AuthService : ServizioBase, IAuthService
{
    private readonly ILogger<AuthService> _logger;

    public AuthService(IConfiguration configuration, ILogger<AuthService> logger) : base(configuration.GetConnectionString("DefaultConnection"))
    {
        _logger = logger;
    }

    public async Task<Utente> LoginAsync(string username, string password)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT IdUtente, Username, Password FROM Utenti WHERE Username = @Username AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Utente
                    {
                        IdUtente = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                }

                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il login.");
            throw;
        }
    }

    public async Task<Utente> RegisterAsync(Utente utente)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Utenti (Username, Password) OUTPUT INSERTED.IdUtente VALUES (@Username, @Password)", connection);
                command.Parameters.AddWithValue("@Username", utente.Username);
                command.Parameters.AddWithValue("@Password", utente.Password);

                await connection.OpenAsync();
                utente.IdUtente = (int)await command.ExecuteScalarAsync();
                return utente;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la registrazione.");
            throw;
        }
    }
}
