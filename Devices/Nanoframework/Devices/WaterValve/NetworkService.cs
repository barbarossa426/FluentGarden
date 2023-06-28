using System;
using System.Net.Http;
using System.Text;
using WaterValve.Models;

namespace WaterValve
{
    public class NetworkService : INetworkService
    {
        public string BaseRoute { get; set; }
        private readonly HttpClient _httpClient = new HttpClient();

        public string ConnectToHub(DeviceRequest request)
        {
            try
            {
                string endpoint = $"{BaseRoute}/devices";

                string requestAsjson = nanoFramework.Json.JsonSerializer.SerializeObject(request);

                var content = new StringContent(requestAsjson, Encoding.UTF8, "application/json");
                var result = _httpClient.Post("https://httpbin.org/anything", content);
                result.EnsureSuccessStatusCode();

                var output = "";
                return output;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public interface INetworkService
    {
        string ConnectToHub(DeviceRequest request);
    }
}