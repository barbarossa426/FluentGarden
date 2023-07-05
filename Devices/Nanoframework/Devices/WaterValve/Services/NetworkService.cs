using System;
using System.Net.Http;
using System.Text;
using WaterValve.Models;

namespace WaterValve.Services
{
    public class NetworkService : INetworkService
    {
        public string BaseRoute { get; private set; }
        private readonly HttpClient _httpClient = new HttpClient();

        public string ConnectToHub(DeviceRequest request)
        {
            try
            {
                string endpoint = $"{BaseRoute}/devices";

                string requestAsjson = nanoFramework.Json.JsonSerializer.SerializeObject(request);

                var content = new StringContent(requestAsjson, Encoding.UTF8, "application/json");
                var result = _httpClient.Post(endpoint, content);
                result.EnsureSuccessStatusCode();

                var output = $"connected";

                return output;
            }
            catch (Exception e)
            {
                return $"{request.Name} | {request.MacAddress} status : disconnected. {e.Message} ";
            }
        }

        public NetworkService SetBaseRoute(string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentNullException(nameof(route));
            }
            BaseRoute = route;
            return this;
        }

        public string ListenToNetworkCommands(string macAddress)
        {
            try
            {
                string endpoint = $"{BaseRoute}/commands/{macAddress}"; //TODO fix url

                var response = _httpClient.Get(endpoint);
                response.EnsureSuccessStatusCode();

                var output = response.Content.ToString(); //TODO parse response

                return output;
            }
            catch (Exception e)
            {
                return $"{macAddress} status : {e.Message}";
            }
        }

        public void RaiseEvent(EventType type, string message)
        {
            throw new NotImplementedException();
        }
    }

    public interface INetworkService
    {
        string ConnectToHub(DeviceRequest request);

        string ListenToNetworkCommands(string macAddress);

        void RaiseEvent(EventType type, string message);
    }
}