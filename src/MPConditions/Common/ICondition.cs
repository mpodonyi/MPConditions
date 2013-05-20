using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{

    public interface ICondition<TSubject>: ICondition
    {
        TSubject SubjectValue {get;}
    }
    
    public interface ICondition
    {
        string SubjectName { get; }

        object OriginalSubjectValue { get; }

        ValidationInfo GetResult();

        void Push(Func<ValidationInfo> action);  
    }
}
