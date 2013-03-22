using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public interface ICondition<T> //MP: try to get rid of T causes errors in ThrowOrGet
    {
        ExecutionContext GetResult();

        void Push(Func<ExecutionContext> action);
    }
}
