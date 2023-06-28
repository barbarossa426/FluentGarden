namespace WaterValve.Models
{
    public class DeviceRequest
    {
        public string MacAddress { get; set; }
        public string Type { get; set; } = "esp32";
        public string Name { get; set; } = string.Empty;
    }
}