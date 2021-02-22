namespace JWTASAuthorization.Models
{
    public interface ITokenManager
    {
        bool Authenticate(string username, string password);
        string NewToken();
    }
}