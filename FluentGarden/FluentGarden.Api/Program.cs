using FluentGarden.Infrastructure.Domain;
using FluentGarden.Infrastructure.Interfaces;
using FluentGarden.Provider;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Provider.Models.Base;
using FluentGarden.Provider.Models.Requests;
using FluentGarden.Repository;
using Microsoft.AspNetCore.Mvc;

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

app.MapPost("/devices", (IHubProvider hubProvider, [FromBody] DeviceRequest request) =>
{
    hubProvider.AddDeviceToHub(request.AsDomainEntity<Device>());
}).WithName("AddDeviceToHub")
  .WithOpenApi();

app.MapDelete("/devices", (IHubProvider hubProvider) => hubProvider.RemoveDeviceFromHub(null!))
    .WithName("RemoveDeviceFromHub")
    .WithOpenApi();

app.MapPost("/devices/trigger", (IHubProvider hubProvider) => hubProvider.TriggerDevice(null!, null!))
    .WithName("TriggerDevice")
    .WithOpenApi();

app.MapGet("/devices", (IHubProvider hubProvider) => hubProvider.ListDevices())
    .WithName("ListDevices")
    .WithOpenApi();

app.MapGet("/device/{macAddress}", (IHubProvider hubProvider, string macAddress) => hubProvider.GetDeviceByMacAddress(macAddress))
    .WithName("GetDeviceByMacAddress")
    .WithOpenApi();

app.MapPost("/device/{ip}/ping", (IHubProvider hubProvider, string ip) => hubProvider.Ping(ip))
    .WithName("Ping")
    .WithOpenApi();

app.MapGet("/device/time", (IHubProvider hubProvider) => hubProvider.GetHubTime())
    .WithName("GetHubTime")
    .WithOpenApi();

app.MapPost("/device/{ip}/checkin", (IHubProvider hubProvider, string ip) => hubProvider.CheckIn(ip))
    .WithName("CheckIn")
    .WithOpenApi();

app.MapPost("/device/setname", (IHubProvider hubProvider) => hubProvider.SetDeviceName(null!, null!))
    .WithName("SetDeviceName")
    .WithOpenApi();

app.MapPost("/groups", (IHubProvider hubProvider) => hubProvider.CreateGroup(null!))
    .WithName("CreateGroup")
    .WithOpenApi();

app.MapDelete("/groups", (IHubProvider hubProvider) => hubProvider.DeleteGroup(null!))
    .WithName("DeleteGroup")
    .WithOpenApi();

app.Run();

public partial class Program
{ }