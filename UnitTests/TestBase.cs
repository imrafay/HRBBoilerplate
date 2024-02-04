using Application.Dto;
using Application.Services;
using FluentAssertions;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UnitTests
{
    public class TestBase
    {
        public ServiceProvider ServiceProvider { get; set; }

        public TestBase()
        {
            var services = new ServiceCollection();

            services.AddAPIDependency()
                .AddInfrastructureDependency()
                .AddApplicationDependency();

            ServiceProvider = services.BuildServiceProvider();
        }

    }
}