using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.Services;

namespace Pokedex.Infra.IoC
{
    public static class DependencyInjectionHealthChecks
    {
        public static IServiceCollection AddInfrastructureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("Default"), tags: new[] { "database" }, name: "SQL Server")
                .AddSendGrid(configuration.GetSection("SendGridEmailSettings").GetValue<string>("APIKey"), name: "SendGrid", tags: new[] { "Server-SMTP" });
                //.AddCheck<OpenAIHealthCheckService>(name: "OpenAI Chat-GPT", tags: new[] { "AI" });

            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5);
                options.MaximumHistoryEntriesPerEndpoint(10);
                options.AddHealthCheckEndpoint("Pokedex API - Health Checks", "/health");
            })
                .AddInMemoryStorage();

            return services;
        }
    }
}
