namespace PCParts.Exceptions;

public class ProductSaveFailedException : Exception
{
    public ProductSaveFailedException(string message) : base(message) { }
}
