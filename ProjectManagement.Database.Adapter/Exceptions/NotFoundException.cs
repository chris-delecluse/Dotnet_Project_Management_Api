namespace ProjectManagement.Database.Adapter.Exceptions;

public class NotFoundException : Exception
{
    private NotFoundException(string message) : base(message) { }

    public static NotFoundException ForMissingEntity(string key) => new($"The entity with key: {key} does not exist.");
}
