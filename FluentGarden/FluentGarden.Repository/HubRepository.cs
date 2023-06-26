using FluentGarden.Repository.Exceptions;
using FluentGarden.Repository.Interfaces;
using FluentGarden.Repository.Models;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace FluentGarden.Repository;

public class HubRepository : IHubRepository
{
    public Hub _hub { get; private set; }

    public HubRepository(string connectionString)
    {
        _hub = new Hub(connectionString);
    }

    public async Task<List<Device>> AddDevice(Device device)
    {
        await SyncHub();

        _hub.AddDevice(device);

        var output = await SaveHub(_hub);

        return output.Devices.ToList();
    }

    public Task<List<Device>> ListDevices()
    {
        throw new NotImplementedException();
    }

    public Task<List<Device>> RemoveDevices()
    {
        throw new NotImplementedException();
    }

    private async Task<HubRepository> SyncHub()
    {
        Stream? jsonStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_hub.ConnectionString);

        if (jsonStream is null)
        {
            throw new HubRepositoryException("Can not read jsonfile");
        }

        StreamReader reader = new StreamReader(jsonStream);
        var jsonString = await reader.ReadToEndAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        Hub? output = JsonSerializer.Deserialize<Hub>(jsonString, options);

        if (output is null)
        {
            throw new HubRepositoryException("Could not Deserialize hub, hub is null");
        }

        _hub = output;
        return this;
    }

    private async Task<Hub> SaveHub(Hub hub)
    {
        try
        {
            string modifiedJsonContent = JsonSerializer.Serialize<Hub>(hub);
            await File.WriteAllTextAsync(hub.ConnectionString, modifiedJsonContent, Encoding.Unicode);
            return hub;
        }
        catch (Exception ex)
        {
            throw new HubRepositoryException("Can not save data", ex);
        }
    }

    public Task<Device> GetDeviceById(Guid id)
    {
        var output = _hub.GetDevice(id);
        return Task.FromResult(output);
    }
}