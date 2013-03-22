using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public interface ICondition<TOriginalValue> //MP: try to get rid of T causes errors in ThrowOrGet
    {
        TOriginalValue OriginalValue { get; }

        ExecutionContext GetResult();

        void Push(Func<ExecutionContext> action);  //MP: maybe move to internal interface
    }
}
