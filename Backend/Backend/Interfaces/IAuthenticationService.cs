using Common.Models.Token;

namespace ShopWebApi.Interfaces
{
    public interface IAuthenticationService
    {
        bool Authenticate(string userName, string password);
        Token GenerateToken();
        bool VerifyToken(string token);
    }
}
