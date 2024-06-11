using DesafioDevFullstack.Infra;
using DesafioDevFullstack.Infra.Data.Interfaces;
using DesafioDevFullstack.Infra.Data;
using Microsoft.EntityFrameworkCore;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Application.Services.Internal;
using DesafioDevFullstack.Application.Services.External.Interfaces;
using DesafioDevFullstack.Application.Services.External;
using DesafioDevFullstack.Application.Mappings;
using Asp.Versioning;
using FluentValidation.AspNetCore;
using DesafioDevFullstack.Domain.Entities;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace DesafioDevFullstack
{
    [ExcludeFromCodeCoverage]
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
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
                });
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

            // Add services to the container.
            builder.Services.AddControllers();

            #region FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<EnderecoValidator>();
            #endregion

            #region Versioning
            // Configure API Versioning
            builder.Services.AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API v1", Version = "v1" });
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API v2", Version = "v2" });
            });

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
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
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
