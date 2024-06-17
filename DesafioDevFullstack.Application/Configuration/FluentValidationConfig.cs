using DesafioDevFullstack.Domain.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioDevFullstack.Application.Configuration
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<EnderecoValidator>();

            return services;
        }
    }
}
