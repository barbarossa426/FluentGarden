using System;
using System.Device.Gpio;
using WaterValve.Models;

namespace WaterValve.Services
{
    public class ActionService : IActionService
    {
        private readonly INetworkService _networkService;

        public ActionService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public bool CloseWaterValve(GpioPin pin, string deviceName)
        {
            try
            {
                pin.Toggle();
                _networkService.RaiseEvent(EventType.Success, $"{deviceName} water valve closed");
                return true;
            }
            catch (Exception e)
            {
                _networkService.RaiseEvent(EventType.Error, $"{deviceName} | {pin.PinNumber} | {e.Message}");
                return false;
            }
        }

        public string ExecuteActionCommands(ActionType action, GpioPin pin, string deviceName)
        {
            switch (action)
            {
                case ActionType.Default:
                    return "Default action executed";

                case ActionType.TurnOnValve:
                    OpenWaterValve(pin, deviceName);
                    return "Valve turned on";

                case ActionType.TurnOffValve:
                    CloseWaterValve(pin, deviceName);
                    return "Valve turned off";

                default:
                    return "Invalid action";
            }
        }

        public string ListenToActionCommands(ActionType action, GpioPin pin)
        {
            throw new NotImplementedException();
        }

        public bool OpenWaterValve(GpioPin pin, string deviceName)
        {
            try
            {
                pin.Toggle();
                _networkService.RaiseEvent(EventType.Success, $"{deviceName} water valve open");
                return true;
            }
            catch (Exception e)
            {
                _networkService.RaiseEvent(EventType.Error, $"{deviceName} | {pin.PinNumber} | {e.Message}");
                return false;
            }
        }
    }

    public interface IActionService
    {
        bool OpenWaterValve(GpioPin pin, string deviceName);

        bool CloseWaterValve(GpioPin pin, string deviceName);

        string ListenToActionCommands(ActionType action, GpioPin pin);

        string ExecuteActionCommands(ActionType action, GpioPin pin, string deviceName);
    }
}