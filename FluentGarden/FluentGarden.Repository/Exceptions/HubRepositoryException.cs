using System.Runtime.Serialization;

namespace FluentGarden.Infrastructure.Exceptions;

public class HubRepositoryException : Exception
{
    public HubRepositoryException()
    {
    }

    public HubRepositoryException(string? message) : base(message)
    {
    }

    public HubRepositoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected HubRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}