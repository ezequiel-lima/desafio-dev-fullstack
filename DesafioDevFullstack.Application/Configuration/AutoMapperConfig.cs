using DesafioDevFullstack.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioDevFullstack.Application.Configuration
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            return services;
        }
    }
}
