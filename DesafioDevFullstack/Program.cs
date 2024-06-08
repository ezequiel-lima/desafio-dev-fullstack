using DesafioDevFullstack.Infra;
using DesafioDevFullstack.Infra.Data.Interfaces;
using DesafioDevFullstack.Infra.Data;
using Microsoft.EntityFrameworkCore;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Application.Services.Internal;
using DesafioDevFullstack.Application.Services.External.Interfaces;
using DesafioDevFullstack.Application.Services.External;
using DesafioDevFullstack.Application.Mappings;

namespace DesafioDevFullstack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors();
            app.MapControllers();
            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DesafioDataContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("DesafioDevFullstack.Infra"));
            });

            #region Services container e Swagger/OpenAPI
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Cors
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader();
                });
            });
            #endregion

            var services = GetServiceCollection(builder);
        }

        private static IServiceCollection GetServiceCollection(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddHttpClient<IEnderecoExternoService, EnderecoExternoService>(client =>
            {
                client.BaseAddress = new Uri("https://brasilapi.com.br/api/cep/v2/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddAutoMapper(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            return services;
        }
    }
}
