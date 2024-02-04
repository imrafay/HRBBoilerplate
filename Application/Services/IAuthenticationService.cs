using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAuthenticationService
    {
        Task<LoginOutputDto> Login(LoginInputDto input);

        Task<RegisterOutputDto> Register(RegisterInputDto input);
    }
}
