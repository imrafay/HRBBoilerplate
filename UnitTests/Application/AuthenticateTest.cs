using Application.Dto;
using Application.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.Application
{
    public class AuthenticateTest : TestBase
    {
        private readonly IAuthenticationService Service;

        public AuthenticateTest()
        {
            Service = ServiceProvider.GetService<IAuthenticationService>();
        }

        [Fact]
        public async Task LoginTest()
        {
            //Arrange
            //Act
            var result = await Service.Login(new LoginInputDto()
            {
                Email = "Email",
                Name = "Test",
                Password = "password"
            });

            //Assert

            result.Should().BeNull();
        }
    }
}