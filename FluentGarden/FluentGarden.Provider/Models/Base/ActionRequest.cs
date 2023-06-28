using FluentGarden.Infrastructure.Domain;

namespace FluentGarden.Provider.Models.Base;

public class ActionRequest
{
}

public static class RequestExtention
{
    public static T AsDomainEntity<T>(this ActionRequest request)
    {
        var targetType = typeof(T);
        var sourceType = request.GetType();

        var output = MapProperties(targetType, request);

        return (T)output;
    }

    private static object MapProperties(Type targetType, dynamic request)
    {
        if (targetType == typeof(Device))
        {

            string type = request.Type;
            string macAddress = request.MacAddress;

            DeviceType deviceType = (DeviceType)Enum.Parse(typeof(DeviceType), type.ToLower());

            Device device = new Device(deviceType, macAddress);

            return device;
        }

        throw new NotImplementedException(nameof(request));
    }
}