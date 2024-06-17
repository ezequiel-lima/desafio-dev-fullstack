using DesafioDevFullstack.Infra;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;
using System.Diagnostics.CodeAnalysis;
using DesafioDevFullstack.Application.Configuration;

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
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
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
            SwaggerConfig.AddSwaggerConfiguration(builder.Services);
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

            AuthenticationConfig.AddJwtAuthentication(builder.Services);
            DependencyInjection.AddProjectDependencies(builder.Services);
            AutoMapperConfig.AddAutoMapperConfiguration(builder.Services);
            FluentValidationConfig.AddFluentValidationConfiguration(builder.Services);
            
        }
    }
}
