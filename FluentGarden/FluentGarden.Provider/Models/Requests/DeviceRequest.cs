using FluentGarden.Provider.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FluentGarden.Provider.Models.Requests;

public class DeviceRequest : Request
{
    public DeviceRequest(string macAddress, string name = "")
    {
        if (string.IsNullOrWhiteSpace(macAddress))
        {
            throw new ArgumentNullException(nameof(macAddress));
        }
        MacAddress = macAddress;
        Name = name;
    }

    [Required]
    public string MacAddress { get; set; }

    public string Name { get; set; } = string.Empty;
}