namespace ProjectManagement.Database.Adapter.Exceptions;

public class BadRequestException : Exception
{
    private BadRequestException(string message) : base(message) { }

    public static BadRequestException ForInsertionFailed() => new("Failed to perform the insertion operation.");
}
