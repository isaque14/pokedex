using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Pokedex.API.Controllers;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Application.Services.ExternalAPI;
using Pokedex.Domain.Account;
using Pokedex.Infra.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureExternalApiPoke(builder.Configuration);
builder.Services.AddInfrastructureSendGrid(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureHealthChecks(builder.Configuration);
builder.Services.AddHttpClient<RequestChatGPTController>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(DependencyInjectionSerilog.AddInfrastructureSerilog(builder.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeDex API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = p => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});


app.UseHealthChecksUI(options => { options.UIPath = "/dashbord";
    options.AddCustomStylesheet("HealthCheckStyle.css");
});

app.MapHealthChecksUI();

app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
