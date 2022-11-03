namespace Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationException> exceptions) : base(string.Join(",",exceptions))
    {
    }
}