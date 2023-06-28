using FluentGarden.Provider.Models.Response;

namespace FluentGarden.Provider.Models.Base;

public class ActionResponse
{
}

public static class ResponseExtention
{
    public static T AsResponse<T>(this object response)
    {
        var targetType = typeof(T);

        var output = MapProperties(targetType, response);

        return (T)output;
    }

    private static object MapProperties(Type targetType, object response)
    {
        if (targetType == typeof(DeviceResponse))
        {
            dynamic dynamicResponse = response;

            string type = dynamicResponse.Type.ToString();
            string macAddress = dynamicResponse.MacAddress;
            string name = dynamicResponse.Name ?? string.Empty;
            string ip = dynamicResponse.Ip ?? string.Empty;

            DeviceResponse device = new DeviceResponse() { Type = type, MacAddress = macAddress, Name = name, Ip = ip };

            return device;
        }

        throw new NotImplementedException(nameof(response));
    }
}