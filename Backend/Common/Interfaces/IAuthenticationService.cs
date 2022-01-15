using Common.Models.Token;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IAuthenticationService
    {
        Token GenerateToken();
        bool VerifyToken(string token);
        void RemoveToken(string token);
    }
}
