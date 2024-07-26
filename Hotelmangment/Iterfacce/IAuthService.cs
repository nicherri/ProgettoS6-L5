namespace Project.Services.Auth
{
    public interface IAuthService
    {
        Task<Utente> LoginAsync(string username, string password);
        Task<Utente> RegisterAsync(Utente utente);
    }
}
