namespace PCParts.Exceptions;

public class CategorySaveFailedException : Exception
{
    public CategorySaveFailedException(string message) : base(message) { }
}
