using Application.Common.Interfaces.Persistence;
using Application.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                Token = "Token",
            };
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
