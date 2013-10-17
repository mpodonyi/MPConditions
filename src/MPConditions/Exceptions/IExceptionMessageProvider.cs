
namespace MPConditions.Exceptions
{
    public interface IExceptionMessageProvider
    {
        string GetExceptionMessage<TOriginalSubject>(ExceptionTypes exceptionType, string subjectName, TOriginalSubject subjectValue, string resourceKey, object[] args);
    }
}
