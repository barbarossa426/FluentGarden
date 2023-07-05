using System;

namespace WaterValve.Models
{
    public class DeviceRequest
    {
        public string MacAddress { get; set; }
        public string Type { get; set; } = "esp32";
        public string Name { get; set; } = string.Empty;

        public DeviceRequest(string macAddress, string type, string name)
        {
            MacAddress = macAddress ?? throw new ArgumentNullException(nameof(macAddress));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}