using nanoFramework.Json;
using System;
using System.Net.Http;
using System.Text;
using WaterValve.Models;
using WaterValve.Services.Events;

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

                //string requestAsjson1 = JsonSerializer.SerializeObject(request);

                string requestAsjson = JsonConvert.SerializeObject(request);


                //var content = new StringContent(requestAsjson, Encoding.UTF8, "application/json");
                //var result = _httpClient.Post(endpoint, content);
                //result.EnsureSuccessStatusCode();

                var output = $"connected";

                return output;
            }
            catch (Exception e)
            {
                return $"{request.Name} | {request.MacAddress} status : disconnected. {e.Message} ";
            }
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

        public NetworkService SetBaseRoute(string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentNullException(nameof(route));
            }
            BaseRoute = route;
            return this;
        }

        public void OnActiontExecuted(object source, ActionServiceEventArgs args)
        {
            try
            {
                string endpoint = $"{BaseRoute}/event";

                string requestAsjson = nanoFramework.Json.JsonSerializer.SerializeObject(args);

                var content = new StringContent(requestAsjson, Encoding.UTF8, "application/json");
                var result = _httpClient.Post(endpoint, content);
                result.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                // :(
            }
        }
    }

    public interface INetworkService
    {
        string ConnectToHub(DeviceRequest request);

        string ListenToNetworkCommands(string macAddress);

        void OnActiontExecuted(object source, ActionServiceEventArgs args);
    }
}