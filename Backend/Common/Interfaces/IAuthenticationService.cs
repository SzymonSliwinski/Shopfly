using Backend.Models.Token;

namespace Backend.Interfaces
{
    public interface IAuthenticationService
    {
        bool Authenticate(string userName, string password);
        Token GenerateToken();
        bool VerifyToken(string token);
    }
}
