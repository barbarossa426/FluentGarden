using FluentGarden.Infrastructure.Interfaces;
using FluentGarden.Provider;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHubRepository, HubRepository>(hubRepository => new HubRepository("FluentGarden.Infrastructure.Database.json"));
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

builder.Services.AddScoped<IHubProvider, HubProvider>();
builder.Services.AddScoped<IGroupProvider, GroupProvider>();

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