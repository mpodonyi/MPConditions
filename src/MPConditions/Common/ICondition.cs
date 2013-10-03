
namespace MPConditions.Common
{
    public interface ICondition<TOriginal> : ICondition, IFluentInterface
    {
        TOriginal OriginalSubjectValue { get; }
        string SubjectName { get; }
        //TSubject SubjectValue {get;}
    }

    public interface ICondition : IFluentInterface
    {
        //    string SubjectName { get; }

        //    object OriginalSubjectValue { get; }

        ValidationInfo GetResult();

        //    void Push(Func<ValidationInfo> action);  
    }
}
