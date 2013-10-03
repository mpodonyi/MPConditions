
namespace MPConditions.Exceptions
{
    public interface IExceptionMessageProvider
    {
        string GetExceptionMessage(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args);
    }
}
