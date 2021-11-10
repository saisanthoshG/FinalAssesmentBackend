﻿using FINALP.SignUp;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FINALP
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
      //  private readonly IDictionary<string, string> users = new Dictionary<string, string> { { "test1", "password1" }, { "test2", "password2" } };
        
        private readonly string key;

       

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string username, string password)
        {
            ProductContext z = new ProductContext();
            var product1 = z.Userdetails.Find(username);
            if (product1 == null || product1.Pwd != password)
            {
                return null;
            }
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
