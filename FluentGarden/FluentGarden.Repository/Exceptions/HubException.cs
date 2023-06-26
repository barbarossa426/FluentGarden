using System.Runtime.Serialization;

namespace FluentGarden.Repository.Exceptions;

public class HubException : Exception
{
    public HubException()
    {
    }

    public HubException(string? message) : base(message)
    {
    }

    public HubException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected HubException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}