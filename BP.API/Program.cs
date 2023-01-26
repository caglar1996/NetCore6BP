using BP.API.Extensions;
using BP.API.Models;
using BP.API.Service;
using BP.API.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BP.API
{
    public class Program
    {
        private static string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{env}.json", optional: true);


            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();
            builder.Services.ConfigureMapping();
            builder.Services.ServiceDependency();

            builder.Services.AddTransient<IValidator<ContactDTO>, ContactValidator>();

            builder.Services.AddHttpClient("GarantiApi", config =>
            {
                config.BaseAddress = new Uri("Https://www.garati.com");
                config.DefaultRequestHeaders.Add("Authorization", "Bearer 12312");
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomHealthCheck();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseResponseCaching();


            app.MapControllers();

            app.Run();
        }
    }
}