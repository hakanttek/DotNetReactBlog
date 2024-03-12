using Microsoft.IdentityModel.Tokens;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Application
{
    public class UserTokenService : IUserTokenService<UserDto>, ITokenService<UserDto>
    {
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public UserTokenService(string jwtKey, string jwtIssuer, string jwtAudience)
        {
            _jwtKey = jwtKey;
            _jwtIssuer = jwtIssuer;
            _jwtAudience = jwtAudience;
        }

        public string CreateJwtToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credinentals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username??""),
                new Claim(ClaimTypes.Role, user.Role ?? "")
            };

            var token = new JwtSecurityToken(
                _jwtIssuer,
                _jwtAudience,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credinentals);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
