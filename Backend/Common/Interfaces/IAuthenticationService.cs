using Common.Models.Token;

namespace Common.Interfaces
{
    public interface IAuthenticationService
    {
        bool Authenticate(string userName, string password);
        Token GenerateToken();
        bool VerifyToken(string token);
        void RemoveToken(string token);
    }
}
