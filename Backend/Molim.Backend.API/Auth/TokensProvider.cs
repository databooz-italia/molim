using Molim.Backend.API.BusinessLayer.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Molim.Backend.API.Auth
{
    public class TokensProvider
    {
        private string secret;
        private int validForMinutes;

        public TokensProvider(JWTConfiguration conf)
        {
            secret = conf.Secret;
            validForMinutes = conf.TokenValidityMinutes;
        }

        public string ProvideToken(int id, string username, TokenType type = TokenType.ShortTerm)
        {
            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = type == TokenType.ShortTerm ? DateTime.UtcNow.AddMinutes(validForMinutes) : DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
            });

            return handler.WriteToken(token);
        }
        
        public enum TokenType
        {
            LongTerm,
            ShortTerm
        }
    }
}
