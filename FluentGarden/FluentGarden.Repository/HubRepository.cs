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
        Gethub();

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

    private HubRepository Gethub()
    {
        //TODO make Async
        Stream? jsonStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_hub.ConnectionString);

        if (jsonStream is null)
        {
            throw new NullReferenceException("Can not read jsonfile");
        }

        StreamReader reader = new StreamReader(jsonStream);
        var jsonString = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        Hub? output = JsonSerializer.Deserialize<Hub>(jsonString, options);

        if (output is null)
        {
            throw new HubRepositoryException("Hub not found");
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
            throw new ArgumentException("Can not save data", ex);
        }
    }
}