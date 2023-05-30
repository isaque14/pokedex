using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Application.Services.ExternalAPI;
using Pokedex.Domain.Account;
using Pokedex.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureExternalApiPoke(builder.Configuration);
builder.Services.AddInfrastructureSendGrid(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
            

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Famdom Star Wars API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseRouting();


using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var seedDatabaseInitial = services.GetRequiredService<ISeedDatabaseService>();
    var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();

    seedUserRoleInitial.SeedRoles();
    seedUserRoleInitial.SeedUsers();

    await seedDatabaseInitial.InserData();
}


app.UseAuthorization();


app.MapControllers();

app.Run();
