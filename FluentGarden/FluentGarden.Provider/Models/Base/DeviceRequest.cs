using FluentGarden.Infrastructure.Domain;

namespace FluentGarden.Provider.Models.Base;

public class Request
{
}

public static class RequestExtention
{
    //public static T AsDomainEntity<T>(this Request request)
    //{
       
    //}


    public static T AsDomainEntity<T>(this Request request)
    {
        var targetType = typeof(T);
        var sourceType = request.GetType();

        var targetInstance = Activator.CreateInstance(targetType);

        var sourceProperties = sourceType.GetProperties();
        var targetProperties = targetType.GetProperties();

        foreach (var sourceProp in sourceProperties)
        {
            var targetProp = targetProperties.FirstOrDefault(
                p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);

            if (targetProp != null && targetProp.CanWrite)
            {
                var value = sourceProp.GetValue(request);
                targetProp.SetValue(targetInstance, value);
            }
        }

        return (T)targetInstance;
    }












}

