namespace PCParts.Exceptions;

public class SaleCreationFailedException : Exception
{
    public SaleCreationFailedException(string message) : base(message) { }
}
