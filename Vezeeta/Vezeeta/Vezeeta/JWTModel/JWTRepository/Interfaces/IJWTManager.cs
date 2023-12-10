using Vezeeta.Models;
using Vezeeta.Parameter;

namespace Vezeeta.TokenModel.JWTRepository.Interfaces
{
    public interface IJWTManager
    {
       Tokens Authenticate(Login user);
    }
}
