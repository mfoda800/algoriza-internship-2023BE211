using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.TokenModel;
using Vezeeta.TokenModel.JWTRepository.Interfaces;

namespace Vezeeta.JWTModel.JWTRepository.Implementation
{
    public class JWTManager : IJWTManager
    {
        private VezeetaContext _Veseta;
        private readonly IConfiguration iconfiguration;
        public JWTManager(VezeetaContext Veseta, IConfiguration iconfiguration)
        {
            _Veseta = Veseta;
            this.iconfiguration = iconfiguration;

        }
        public Tokens Authenticate(Login user)
        {

            if (!_Veseta.Users.Any(x => x.Name == user.Name && x.Password == user.Password))
            {
                return new Tokens { Token = null,RefreshToken=null,Message="Invalid Name Or Password" };
            }
            //  generate JSON Web Token
            var UserData = _Veseta.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, UserData.Name)
              }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var Auth_Token = tokenHandler.WriteToken(token);

            Tokens User_Auth = new Tokens
            {
                Token = Auth_Token,
                RefreshToken = "",
                Message="Success"
            };

            return User_Auth;
        }
    }
}
