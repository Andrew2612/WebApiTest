namespace TestWebApp.Helpers.BasicException;

public class BasicException : Exception
{
    protected BasicException(string id, string message): base(message: $"{id}: {message}") { }
}