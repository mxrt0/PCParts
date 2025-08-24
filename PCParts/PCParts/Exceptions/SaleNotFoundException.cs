namespace PCParts.Exceptions;

public class SaleNotFoundException : Exception
{
    public SaleNotFoundException(string message) : base(message) { }
}
