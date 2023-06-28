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
            string name = dynamicResponse.Name;

            DeviceResponse device = new DeviceResponse(type, macAddress, name);

            return device;
        }

        throw new NotImplementedException(nameof(response));
    }
}