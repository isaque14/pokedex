using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace Pokedex.Infra.IoC
{
    public class DependencyInjectionSerilog
    {
        public static Logger AddInfrastructureSerilog(IConfiguration configuration)
        {
            try
            {
                var keySecret = configuration["ConnectionStrings:Default"];

                Logger logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.MSSqlServer(
                        connectionString: keySecret,
                        sinkOptions: new MSSqlServerSinkOptions
                        {
                            TableName = "Logs",
                            AutoCreateSqlTable = true
                        })
                    .CreateLogger();

                return logger;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
