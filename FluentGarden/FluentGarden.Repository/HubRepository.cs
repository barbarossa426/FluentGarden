using FluentGarden.Repository.Interfaces;
using FluentGarden.Repository.Models;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace FluentGarden.Repository;

public class HubRepository : IHubRepository
{
    public async Task<List<Device>> AddDevice(Device device)
    {
        Hub? data = ReadDatabase();
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        data.AddDevice(device);

        var output = await WriteToDatabaseAsync(data);

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

    private Hub? ReadDatabase(string file = "FluentGarden.Repository.Database.json")
    {
        //TODO make Async
        Stream? jsonStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(file);

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
        return output;
    }

    private async Task<Hub> WriteToDatabaseAsync(Hub data, string file = "FluentGarden.Repository.Database.json")
    {
        try
        {
            string modifiedJsonContent = JsonSerializer.Serialize<Hub>(data);
            await File.WriteAllTextAsync(file, modifiedJsonContent, Encoding.Unicode);
            return data;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Can not save data", ex);
        }
    }
}