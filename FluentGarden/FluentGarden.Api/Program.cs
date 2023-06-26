using FluentGarden.Provider;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Repository;
using FluentGarden.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHubRepository, HubRepository>(hubRepository => new HubRepository("FluentGarden.Repository.Database.json"));
builder.Services.AddScoped<IHubProvider, HubProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/addDevice", () =>
{
})
.WithName("AddDeviceToHub")
.WithOpenApi();

app.Run();

public partial class Program
{ }