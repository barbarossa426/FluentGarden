using nanoFramework.DependencyInjection;
using System.Device.Gpio;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using WaterValve.Models;
using WaterValve.Services;

namespace WaterValve
{
    public class Program
    {
        private static string baseRoute = "localhost"; //TODO Set this somewhere //appsettings?
        private static int pinNumber = 1; //TODO Set this somewhere //appsettings?
        private static string deviceType = "esp32"; //TODO Set this somewhere //appsettings?
        private static string deviceName = "flowerpots"; //TODO Set this somewhere //appsettings?

        private static string macAddress;
        private static string networkStatus;

        public static void Main()
        {
            ServiceProvider serviceProvider = InjectServices();
            var networkService = GetNetworkService(serviceProvider, baseRoute);
            var actionService = GetActionService(serviceProvider);

            Debug.WriteLine("Hello from nanoFramework!");

            int connectTimes = 0;

            while (true)
            {
                if (networkStatus != "connected")
                {
                    //try connect to network 5 times
                    if (string.IsNullOrEmpty(macAddress) && connectTimes <= 5)
                    {
                        SetMac(); // moment 22 ?? can I have a mac withoud beeing connected to the network ??
                        connectTimes = +1;
                    }

                    if (string.IsNullOrEmpty(macAddress) is false && string.IsNullOrEmpty(networkStatus))
                    {
                        DeviceRequest request = new DeviceRequest(macAddress, deviceType, deviceName);
                        networkStatus = networkService.ConnectToHub(request);
                    }
                }
                else
                {
                    Debug.WriteLine(networkStatus);
                }

                string actionString = networkService.ListenToNetworkCommands(macAddress);
                ExecuteAction(actionService, actionString);

                Thread.Sleep(3000);
            }

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }

        private static void ExecuteAction(ActionService actionService, string actionString)
        {
            GpioPin input = new GpioController().OpenPin(pinNumber);
            ActionType action;

            //Cant parse string to enum :/ Enum.TryParse<ActionType>(actionString, out ActionType action) --> not working
            switch (actionString)
            {
                case "TurnOffValve":
                    action = ActionType.TurnOffValve;
                    break;

                case "TurnOnValve":
                    action = ActionType.TurnOnValve;
                    break;

                default:
                    action = ActionType.Default;
                    break;
            }

            actionService.ExecuteActionCommands(action, input, deviceName);
        }

        private static void SetMac()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                macAddress = adapter.PhysicalAddress.ToString();
            }
        }

        private static ServiceProvider InjectServices()
        {
            return new ServiceCollection()
           .AddSingleton(typeof(INetworkService), typeof(NetworkService))
           .AddSingleton(typeof(IActionService), typeof(ActionService))
           .BuildServiceProvider();
        }

        private static NetworkService GetNetworkService(ServiceProvider serviceProvider, string baseRoute)
        {
            NetworkService output = (NetworkService)serviceProvider.GetService(typeof(NetworkService));
            output.SetBaseRoute(baseRoute);
            return output;
        }

        private static ActionService GetActionService(ServiceProvider serviceProvider)
        {
            ActionService output = (ActionService)serviceProvider.GetService(typeof(ActionService));
            return output;
        }
    }
}