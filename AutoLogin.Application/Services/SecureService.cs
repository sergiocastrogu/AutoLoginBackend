using AutoLogin.Application.Interfaces;
using AutoLogin.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutoLogin.Application.Services
{
    internal class SecureService : ISecureService
    {

        private readonly IConfiguration _configuration;

        public SecureService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var jwtSetting = _configuration.GetSection("JWTSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var calims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData, user.UserName),
                new Claim(ClaimTypes.Dns, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSetting["Issuer"],
                audience: jwtSetting["Audience"],
                claims: calims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSetting["ExpiresInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
