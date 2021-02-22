using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JWTASAuthorization.Models
{
    public class TokenManager : ITokenManager
    {
        public bool Authenticate(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) &&
                username.ToLower() == "admin" && password == "password";
        }

        public string NewToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"));
            var issuer = "http://mysite.com";
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "bilal"));

            //Create Security Token object by giving required parameters    
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials));
        }
    }
}