namespace Hotelmangment.Services.Auth
{
    public interface IAuthService
    {
        Task<Utente> LoginAsync(string username, string password);
        Task<Utente> RegisterAsync(string username, string password);
    }
}
