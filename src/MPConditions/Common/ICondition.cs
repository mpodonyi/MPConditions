using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    
    public interface ICondition//<TSubject>
    {
        //TSubject Subject { get; }

        string SubjectName { get; }

        object OriginalSubject { get; }

        ValidationInfo GetResult();
    }

    public interface IConditionInternal 
    {
        void Push(Func<ValidationInfo> action);  
    }
}
