using DesafioDevFullstack.Application.Services.External;
using DesafioDevFullstack.Application.Services.External.Interfaces;
using DesafioDevFullstack.Application.Services.Internal;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Infra.Data;
using DesafioDevFullstack.Infra.Data.Interfaces;
using DesafioDevFullstack.Infra.Data.Repositories;
using DesafioDevFullstack.Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioDevFullstack.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddHttpClient<IEnderecoExternoService, EnderecoExternoService>(client =>
            {
                client.BaseAddress = new Uri("https://brasilapi.com.br/api/cep/v2/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
