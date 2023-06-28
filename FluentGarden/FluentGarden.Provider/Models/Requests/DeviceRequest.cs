using FluentGarden.Provider.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FluentGarden.Provider.Models.Requests;

public class DeviceRequest : ActionRequest
{
    public DeviceRequest(string macAddress, string type, string name = "")
    {
        if (string.IsNullOrWhiteSpace(macAddress))
        {
            throw new ArgumentNullException(nameof(macAddress));
        }
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentNullException(nameof(macAddress));
        }
        MacAddress = macAddress;
        Type = type;
        Name = name;
    }

    [Required]
    public string MacAddress { get; set; }

    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}