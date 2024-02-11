using Application.Common.Interfaces.Persistence;
using Application.Dto;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            IUserRepository userRepository,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LoginOutputDto> Login(LoginInputDto input)
        {
            var user = await _userRepository.GetUserByIdAsync(input.Email, input.Password);

            if (user == null)
            {
                throw new ApplicationException("Could not found a user");
            }

            return new LoginOutputDto()
            {
                Email = user.EmailAddress,
                Id = user.Id,
                Name = user.Name,
                Token = await GenerateJwtToken(user),
            };
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]
                ));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];

            var token = new JwtSecurityToken(
                issuer:issuer,
                audience:audience,
                claims:claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials:signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegisterOutputDto> Register(RegisterInputDto input)
        {
            var userId = Guid.NewGuid();
            await _userRepository.AddAsync(new User()
            {
                EmailAddress = input.Email,
                Id = userId,
                Name = input.Name,
                Password = input.Password,
            });

            return new RegisterOutputDto()
            {
                Email = input.Email,
                Id = userId
            };
        }
    }
}
