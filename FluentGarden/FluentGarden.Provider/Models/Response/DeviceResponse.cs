using FluentGarden.Provider.Models.Base;
using System.Text.Json.Serialization;

namespace FluentGarden.Provider.Models.Response;

public class DeviceResponse : ActionResponse
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; }
    public string MacAddress { get; set; }

    public string Ip { get; set; } = string.Empty;

    //public DeviceResponse(string type, string macAddress, string name = "", string ipAddress = "")
    //{
    //    if (string.IsNullOrEmpty(macAddress)) throw new ArgumentNullException(nameof(macAddress));
    //    if (string.IsNullOrEmpty(type)) throw new ArgumentNullException(nameof(type));

    //    Name = name;
    //    IpAddress = ipAddress;
    //    Type = type;
    //    MacAddress = macAddress;
    //}   
}